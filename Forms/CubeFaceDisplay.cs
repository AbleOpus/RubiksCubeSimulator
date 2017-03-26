using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RubiksCubeSimulator.ColorGrid;
using RubiksCubeSimulator.Properties;
using RubiksCubeSimulator.Rubiks;

namespace RubiksCubeSimulator.Forms
{
    /// <summary>
    /// Specifies a mode for adjusting the cube colors.
    /// </summary>
    public enum ClickMode
    {
        /// <summary>
        /// No effect will happen.
        /// </summary>
        None,
        /// <summary>
        /// The user will be able to rotate with the left and right mouse buttons.
        /// </summary>
        Rotation,
        /// <summary>
        /// The user will be able to set colors with the right mouse buttons.
        /// </summary>
        ColorSet
    }

    /// <summary>
    /// Represents a grid point mapper, to build point arrays on a grid.
    /// </summary>
    internal class CubeFaceDisplay : Control
    {
        private RectangleF hoveredRect;

        private static readonly Cursor rotateCursor = new Cursor(Resources.rotate.GetHicon());

        #region Properties
        private ColorGridStyle Style =>
            new ColorGridStyle(GetDisplayColors(), 0.05f, RoundedRadius);

        private ClickMode clickMode;
        [Category("Appearance")]
        [DefaultValue(ClickMode.None)]
        [Description("The operations to perform when clicking")]
        public ClickMode ClickMode
        {
            get { return clickMode; }
            set
            {
                if (clickMode == value) return;
                clickMode = value;

                switch (clickMode)
                {
                    case ClickMode.ColorSet: Cursor = Cursors.Default; break;
                    case ClickMode.Rotation: Cursor = rotateCursor; break;
                    default: Cursor = Cursors.Default; break;
                }

  
                Invalidate();
            }
        }

        private CubeSide face = CubeSide.None;
        [Category("Appearance"),DefaultValue(CubeSide.None)]
        [Description("The face or side of the cube to handle and display")]
        public CubeSide Face
        {
            get { return face; }
            set
            {
                face = value;
                Invalidate();
            }
        }

        private Color newColor;
        [Description("Determines the color to be set when right-clicking a cell")]
        [Category("Behavior")]
        public Color NewColor
        {
            get { return newColor; }
            set
            {
                if (newColor != value)
                {
                    newColor = value;
                    Invalidate();
                }
            }
        }

        private RubiksCube rubiksCube;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RubiksCube RubiksCube
        {
            get { return rubiksCube; }
            set
            {
                rubiksCube = value;
                Invalidate();
            }
        }

        private Color[,] FaceColors
        {
            get
            {
                if (rubiksCube == null) return null;

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

        private int roundedRadius = 5;
        [Category("Appearance"),DefaultValue(5)]
        [Description("The corner radius of the rounded rectangles used with this control")]
        public int RoundedRadius
        {
            get { return roundedRadius; }
            set
            {
                roundedRadius = value;
                Invalidate();
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
            SetStyle(ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);
            base.BackColor = Color.Transparent;
        }

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            rotateCursor.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.Clear(GetBackColor());
            ColorGridRendering.Draw(Style, e.Graphics, ClientSize, Enabled);

            if (ClickMode == ClickMode.ColorSet && hoveredRect != Rectangle.Empty)
            {
                var path = RoundedRectangleF.Create(hoveredRect, RoundedRadius);
                Pen pen = new Pen(Color.White, 3f);
                pen.Alignment = PenAlignment.Center;
                e.Graphics.DrawPath(pen, path);
                pen.Dispose();
            }
            else if (ClickMode == ClickMode.Rotation)
            {
                var rect = ColorGridRendering.GetMasterRectangle(Style, Size);

                if (rect.Contains(PointToClient(Cursor.Position)))
                {
                    ControlPaint.DrawBorder3D(e.Graphics, Rectangle.Truncate(rect),
                        Border3DStyle.Flat);
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hoveredRect = Rectangle.Empty;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var point = ColorGridRendering.GetGridPointFromPosition
              (Style, e.Location, ClientSize);

            if (point.X != -1 && ClickMode == ClickMode.ColorSet && NewColor != Color.Empty)
            {
                FaceColors[point.X, point.Y] = NewColor;
                OnCellMouseClicked(point, e.Button);
            }
            else if (ClickMode == ClickMode.Rotation)
            {
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;
                var r = (e.Button == MouseButtons.Left) ? Rotation.Ccw : Rotation.Cw;
                rubiksCube.MakeMove(Face, r);
                InvalidateOtherCubeControls();
            }

            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var rect = ColorGridRendering.GetCellRectFromPosition
                (Style, e.Location, ClientSize);

            if (rect != hoveredRect)
            {
                hoveredRect = rect;
                OnHoverCellChanged(hoveredRect);

                if (ClickMode != ClickMode.None)
                    Invalidate();
            }
        }

        protected override Size DefaultSize => new Size(300, 300);

        [Description("Occurs when a new cell has been hovered over by the mouse")]
        public event EventHandler<RectangleF> HoveredCellChanged;
        /// <summary>
        /// Raises the <see cref="HoveredCellChanged"/> event.
        /// </summary>
        protected virtual void OnHoverCellChanged(RectangleF cellPos)
        {
            HoveredCellChanged?.Invoke(this, cellPos);
        }

        [Description("Occurs when a cell has been clicked by the mouse")]
        public event EventHandler<CellMouseClickedEventArgs> CellMouseClicked;
        /// <summary>
        /// Raises the <see cref="CellMouseClicked"/> event
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
            Invalidate();
        }
        #endregion

        private Color[,] GetDisplayColors()
        {
            var faceColors = FaceColors;
            // If face == null then the CubeSide enum has not been set.
            if (rubiksCube == null || faceColors == null)
            {
                return RubiksCube.CreateFace(Color.White);
            }

            return faceColors;
        }

        /// <summary>
        /// Gets the appropriate background color for painting.
        /// </summary>
        private Color GetBackColor()
        {
            if (BackColor == Color.Transparent && Parent != null)
                return Parent.BackColor;
            else
                return BackColor;
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
                    display.RubiksCube == RubiksCube)
                    display.Invalidate();
            }
        }
    }

    /// <summary>
    /// Represents event arguments for the <see cref="CubeFaceDisplay.CellMouseClicked"/> event.
    /// </summary>
    internal class CellMouseClickedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the position of the cell.
        /// </summary>
        public Point CellPosition { get; }

        /// <summary>
        /// Gets the x position of the cell.
        /// </summary>
        public int CellX => CellPosition.X;

        /// <summary>
        /// Gets the y position of the cell.
        /// </summary>
        public int CellY => CellPosition.Y;

        /// <summary>
        /// Gets the buttons used to click the cell.
        /// </summary>
        public MouseButtons Buttons { get;  }

        /// <summary>
        /// Initializes a new instance of the <see cref="CellMouseClickedEventArgs"/>
        /// class with the specified arguments.
        /// </summary>
        /// <param name="cellPos">The position of the cell.</param>
        /// <param name="buttons">The buttons used to click the cell.</param>
        public CellMouseClickedEventArgs(Point cellPos, MouseButtons buttons)
        {
            CellPosition = cellPos;
            Buttons = buttons;
        }
    }
}
