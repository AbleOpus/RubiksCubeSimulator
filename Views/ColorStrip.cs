using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RubiksCubeSimulator.Views
{
    /// <summary>
    /// Represents predefined colors to be picked from
    /// </summary>
    [DefaultEvent("SelectedIndexChanged")]
    class ColorStrip : Panel
    {
        #region Properties
        private Color[] _colors;
        [Description("The array of colors to pick from")]
        [Category("Appearance")]
        [DefaultValue(null)]
        public Color[] Colors
        {
            get { return _colors; }
            set
            {
                _selectedIndex = -1; // Let the user do the reset selection logic
                _colors = value;
                this.Invalidate();
            }
        }

        private int _selectedIndex = -1;
        [Description("The index of the color selected")]
        [Category("Input")]
        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex == value) return;

                if (_colors == null || _colors.Length == 0)
                    throw new InvalidOperationException("There are no colors to selected");

                if (value >= _colors.Length)
                    throw new ArgumentOutOfRangeException("Index must be less than Colors.Count", "value");

                _selectedIndex = value;
                this.Invalidate();
                SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the currently selected color
        /// </summary>
        [Browsable(false)]
        public Color SelectedColor
        {
            get
            {
                if (_selectedIndex == -1) return Color.Empty;
                return _colors[_selectedIndex];
            }
        }

        /// <summary>
        /// Gets whether a color is selected
        /// </summary>
        [Browsable(false)]
        public bool HasSelection
        {
            get { return _selectedIndex != -1; }
        }
        #endregion

        [Description("Occurs when the value of the SelectedIndex property has changed")]
        public event EventHandler SelectedIndexChanged = delegate { };

        public ColorStrip()
        {
            base.DoubleBuffered = true;
            base.ResizeRedraw = true;
        }

        private RectangleF[] GetColorRects()
        {
            if (_colors == null) return new RectangleF[] { };
            float width = (float)Width / _colors.Length;

            var rects = new List<RectangleF>();

            for (int i = 0; i < _colors.Length; i++)
            {
                rects.Add(new RectangleF(width * i, 0, width, Height));
            }

            return rects.ToArray();
        }

        private RectangleF GetColorRect(int index)
        {
            float width = (float)Width / _colors.Length;
            return new RectangleF(index * width, 0, width, Height);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            var rects = GetColorRects();

            for (int i = 0; i < rects.Length; i++)
            {
                if (rects[i].Contains(e.Location))
                    SelectedIndex = i;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_colors == null) return;
           
            Color borderColor = Enabled ? Color.Black : Color.Gray;
            Pen borderPen = new Pen(borderColor, 1);

            // Draw colors
            for (int i = 0; i < _colors.Length; i++)
            {
                var rect = GetColorRect(i);
                var brush = new SolidBrush(_colors[i]);
                if (!Enabled) brush.Color = brush.Color.Desaturate();
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y - 1, rect.Width, rect.Height);
            }

            // Draw master border
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);

            // Draw selected border
            for (int i = 0; i < _colors.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    var rect = GetColorRect(i);
                    const int RGBMAX = 255;
                    const int BORDER_WIDTH = 4;
                    var color = Color.FromArgb(RGBMAX - _colors[i].R, RGBMAX - _colors[i].G, RGBMAX - _colors[i].B);
                    if (!Enabled) color = Color.DimGray;
                    Pen pen = new Pen(color, BORDER_WIDTH);
                    e.Graphics.DrawRectangle(pen, rect.X + BORDER_WIDTH / 2,
                        rect.Y + BORDER_WIDTH / 2, rect.Width - BORDER_WIDTH, rect.Height - BORDER_WIDTH);
                    // Draw inner small border
                    e.Graphics.DrawRectangle(borderPen, rect.X + BORDER_WIDTH, rect.Y + BORDER_WIDTH,
                        rect.Width - BORDER_WIDTH * 2, rect.Height - BORDER_WIDTH * 2);
                    // Draw outer 
                    float width = rect.Width;
                    if (i == _colors.Length - 1) width = this.Width - rect.X - 1;
                    e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, width, rect.Height - 1);
                }
            }
        }
    }
}
