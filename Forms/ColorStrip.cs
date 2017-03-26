using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RubiksCubeSimulator.Forms
{
    /// <summary>
    /// Represents predefined colors to be picked from
    /// </summary>
    [DefaultEvent(nameof(SelectedIndexChanged))]
    internal class ColorStrip : Panel
    {
        #region Properties
        private Color[] colors;
        [Description("The array of colors to pick from.")]
        [Category("Appearance"), DefaultValue(null)]
        public Color[] Colors
        {
            get { return colors; }
            set
            {
                selectedIndex = -1; // Let the user do the reset selection logic
                colors = value;
                Invalidate();
            }
        }

        private int selectedIndex = -1;
        [Description("The index of the color selected.")]
        [Category("Input"), DefaultValue(-1)]
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex == value) return;

                if (colors == null || colors.Length == 0)
                    throw new InvalidOperationException("There are no colors to selected");

                if (value >= colors.Length)
                    throw new ArgumentOutOfRangeException("Index must be less than Colors.Count", nameof(value));

                selectedIndex = value;
                Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the currently selected color.
        /// </summary>
        [Browsable(false)]
        public Color SelectedColor => 
            selectedIndex == -1 ? Color.Empty : colors[selectedIndex];

        /// <summary>
        /// Gets whether a color is selected.
        /// </summary>
        [Browsable(false)]
        public bool HasSelection => selectedIndex != -1;

        #endregion

        [Description("Occurs when the value of the SelectedIndex property has changed.")]
        public event EventHandler SelectedIndexChanged = delegate { };

        public ColorStrip()
        {
            base.DoubleBuffered = true;
            base.ResizeRedraw = true;
        }

        private RectangleF[] GetColorRects()
        {
            if (colors == null) return new RectangleF[] { };
            float width = (float)Width / colors.Length;

            var rects = new List<RectangleF>();

            for (int i = 0; i < colors.Length; i++)
            {
                rects.Add(new RectangleF(width * i, 0, width, Height));
            }

            return rects.ToArray();
        }

        private RectangleF GetColorRect(int index)
        {
            float width = (float)Width / colors.Length;
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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (colors == null) return;

            Color borderColor = Enabled ? Color.Black : Color.Gray;
            Pen borderPen = new Pen(borderColor, 1);

            // Draw colors
            for (int i = 0; i < colors.Length; i++)
            {
                var rect = GetColorRect(i);
                var brush = new SolidBrush(colors[i]);
                if (!Enabled) brush.Color = brush.Color.Desaturate();
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y - 1, rect.Width, rect.Height);
                brush.Dispose();
            }

            // Draw master border
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);

            // Draw selected border
            const int RGBMAX = 255;
            const int BORDER_WIDTH = 4;

            for (int i = 0; i < colors.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    var rect = GetColorRect(i);
                    var color = Color.FromArgb(RGBMAX - colors[i].R, RGBMAX - colors[i].G, RGBMAX - colors[i].B);
                    if (!Enabled) color = Color.DimGray;
                    Pen pen = new Pen(color, BORDER_WIDTH);
                    e.Graphics.DrawRectangle(pen, rect.X + BORDER_WIDTH / 2f,
                        rect.Y + BORDER_WIDTH / 2f, rect.Width - BORDER_WIDTH, rect.Height - BORDER_WIDTH);
                    pen.Dispose();
                    // Draw inner small border
                    e.Graphics.DrawRectangle(borderPen, rect.X + BORDER_WIDTH, rect.Y + BORDER_WIDTH,
                        rect.Width - BORDER_WIDTH * 2, rect.Height - BORDER_WIDTH * 2);
                    // Draw outer 
                    float width = rect.Width;

                    if (i == colors.Length - 1)
                        width = Width - rect.X - 1;

                    e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, width, rect.Height - 1);
                }
            }

            borderPen.Dispose();
        }
    }
}
