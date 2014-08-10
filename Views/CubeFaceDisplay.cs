using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RubiksCubeSimulator.ColorGrid;
using RubiksCubeSimulator.Rubiks;

namespace RubiksCubeSimulator.Views
{
    /// <summary>
    /// Specifies a mode for adjusting the cube colors
    /// </summary>
    public enum ClickMode
    {
        /// <summary>
        /// No effect will happen
        /// </summary>
        None,
        /// <summary>
        /// The user will be able to rotate with the left and right mouse buttons
        /// </summary>
        Rotation,
        /// <summary>
        /// The user will be able to set colors with the right mouse buttons
        /// </summary>
        ColorSet
    }

    /// <summary>
    /// Represents a grid point mapper, to build point arrays on a grid
    /// </summary>
    [DefaultEvent("PointsChanged")]
    class CubeFaceDisplay : Control
    {
        private RectangleF _hoveredRect;

        #region Properties
        private ColorGridStyle Style
        {
            get
            {
                return new ColorGridStyle(GetDisplayColors(), 0.05f, RoundedRadius);
            }
        }

        private ClickMode _clickMode;
        [Category("Appearance")]
        [DefaultValue(ClickMode.None)]
        [Description("The operations to perform when clicking")]
        public ClickMode ClickMode
        {
            get { return _clickMode; }
            set
            {
                if (_clickMode == value) return;
                _clickMode = value;

                if (_clickMode == ClickMode.ColorSet)
                {
                    this.Cursor = Cursors.Hand;
                }
                else if (_clickMode == ClickMode.Rotation)
                {
                    this.Cursor = Cursors.NoMoveHoriz;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                this.Invalidate();
            }
        }

        private CubeSide _face = CubeSide.None;
        [Category("Appearance")]
        [DefaultValue(CubeSide.None)]
        [Description("The face or side of the cube to handle and display")]
        public CubeSide Face
        {
            get { return _face; }
            set
            {
                _face = value;
                this.Invalidate();
            }
        }

        private Color _newColor;
        [Description("Determines the color to be set when right-clicking a cell")]
        [Category("Behavior")]
        public Color NewColor
        {
            get { return _newColor; }
            set
            {
                if (_newColor == value) return;
                _newColor = value;
                this.Invalidate();
            }
        }

        private RubiksCube _rubiksCube;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RubiksCube RubiksCube
        {
            get { return _rubiksCube; }
            set
            {
                _rubiksCube = value;
                this.Invalidate();
            }
        }

        private Color[,] FaceColors
        {
            get
            {
                if (_rubiksCube == null) return null;

                switch (Face)
                {
                    case CubeSide.Front: return RubiksCube.FrontColors;
                    case CubeSide.Back: return RubiksCube.BackColors;
                    case CubeSide.Right: return RubiksCube.RightColors;
                    case CubeSide.Left: return RubiksCube.LeftColors;
                    case CubeSide.Up: return RubiksCube.UpColors;
                    case CubeSide.Down: return RubiksCube.DownColors;
                    default: return null;
                }
            }
        }

        private int _roundedRadius = 5;
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("The corner radius of the rounded rectangles used with this control")]
        public int RoundedRadius
        {
            get { return _roundedRadius; }
            set
            {
                _roundedRadius = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        #endregion

        public CubeFaceDisplay()
        {
            ClickMode = ClickMode.None;

            this.SetStyle(ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);

            base.BackColor = Color.Transparent;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var rect = ColorGridRendering.GetCellRectFromPosition
                (Style, e.Location, this.ClientSize);

            if (rect != _hoveredRect)
            {
                _hoveredRect = rect;
                OnHoverCellChanged(_hoveredRect);

                if (ClickMode != ClickMode.None)
                    this.Invalidate();
            }
        }

        #region Overrides
        [Description("Occurs when a new cell has been hovered over by the mouse")]
        public event EventHandler<RectangleF> HoveredCellChanged;
        /// <summary>
        /// Raises the HoveredCellChanged event
        /// </summary>
        protected virtual void OnHoverCellChanged(RectangleF cellPos)
        {
            if (HoveredCellChanged != null)
            {
                HoveredCellChanged(this, cellPos);
            }
        }

        [Description("Occurs when a cell has been clicked by the mouse")]
        public event EventHandler<CellMouseClickedEventArgs> CellMouseClicked;
        /// <summary>
        /// Raises the CellMouseClicked event
        /// </summary>
        protected virtual void OnCellMouseClicked(Point pos, MouseButtons buttons)
        {
            if (CellMouseClicked != null)
            {
                var args = new CellMouseClickedEventArgs(pos, buttons);
                CellMouseClicked(this, args);
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        /// <summary>
        /// Gets the appropriate background color for painting
        /// </summary>
        private Color GetBackColor()
        {
            if (this.BackColor == Color.Transparent && this.Parent != null)
                return Parent.BackColor;
            else
                return BackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.Clear(GetBackColor());
            ColorGridRendering.Draw(Style, e.Graphics, ClientSize, Enabled);

            if (ClickMode == ClickMode.ColorSet && _hoveredRect != Rectangle.Empty)
            {
                var path = RoundedRectangleF.Create(_hoveredRect, RoundedRadius);
                Pen pen = new Pen(Color.White, 3f);
                pen.Alignment = PenAlignment.Center;
                e.Graphics.DrawPath(pen, path);
            }
            else if (ClickMode == ClickMode.Rotation)
            {
                var rect = ColorGridRendering.GetMasterRectangle(Style, this.Size);

                if (rect.Contains(this.PointToClient(Cursor.Position)))
                {
                    //var path = RoundedRectangleF.Create(rect, RoundedRadius);
                    //Pen pen = new Pen(Color.Gray, 8f);
                    // e.Graphics.DrawPath(pen, path);
                    ControlPaint.DrawBorder3D(e.Graphics, rect.ToRect(),
                        Border3DStyle.Flat);
                }
            }
        }

        private Color[,] GetDisplayColors()
        {
            var face = FaceColors;
            // If face == null then the CubeSide enum has not been set
            if (_rubiksCube == null || face == null)
            {
                return RubiksCube.CreateFace(Color.White);
            }
            else return face;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hoveredRect = Rectangle.Empty;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var point = ColorGridRendering.GetGridPointFromPosition
              (Style, e.Location, ClientSize);

            if (point.X != -1 && ClickMode == ClickMode.ColorSet &&
                NewColor != Color.Empty)
            {
                FaceColors[point.X, point.Y] = NewColor;
                OnCellMouseClicked(point, e.Button);
            }
            else if (ClickMode == ClickMode.Rotation)
            {
                var r = (e.Button == MouseButtons.Left) ? Rotation.Ccw : Rotation.Cw;
                _rubiksCube.MakeMove(Face, r);
                InvalidateOtherCubeControls();
            }

            this.Invalidate();
        }

        // Rotation of a single face results in change of colors in othe faces
        // so show the changes right away
        private void InvalidateOtherCubeControls()
        {
            if (Parent == null) return;

            foreach (Control control in Parent.Controls)
            {
                var display = control as CubeFaceDisplay;
                // Equality with this because we are already invalidating elsewhere
                // and have the same rubik cube
                if (display != null && display != this &&
                    display.RubiksCube == this.RubiksCube) display.Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get { return new Size(300, 300); }
        }
        #endregion
    }


    /// <summary>
    /// Represents event arguments for the cref="CellMouseClicked" event
    /// </summary>
    class CellMouseClickedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the position of the cell
        /// </summary>
        public Point CellPosition { get; private set; }

        /// <summary>
        /// Gets the x position of the cell
        /// </summary>
        public int CellX
        {
            get { return CellPosition.X; }
        }

        /// <summary>
        /// Gets the y position of the cell
        /// </summary>
        public int CellY
        {
            get { return CellPosition.Y; }
        }

        public MouseButtons Buttons { get; private set; }

        public CellMouseClickedEventArgs(Point cellPos, MouseButtons buttons)
        {
            CellPosition = cellPos;
            Buttons = buttons;
        }
    }
}
