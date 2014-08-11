using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a 3x3 rubiks cube
    /// </summary>
    class RubiksCube : ICloneable
    {
        private readonly Color[][,] _origColors;

        #region Properties

        private bool _raiseEvents = true;

        public bool RaiseEvents
        {
            get { return _raiseEvents; }
            set { _raiseEvents = value; }
        }

        private Color[][,] _allColors = new Color[6][,];
        /// <summary>
        /// Gets the color matrix for this cube. Face arrays are as follows:
        /// Front 0, Back 1, Right 2, left 3, Up 4, Down 5
        /// </summary>
        public Color[][,] AllColors
        {
            get { return _allColors; }
        }

        public Color[,] FrontColors
        {
            get { return _allColors[0]; }
            private set
            {
                if (_allColors[0] == value) return;
                _allColors[0] = value;
            }
        }

        public Color[,] BackColors
        {
            get { return _allColors[1]; }
            private set
            {
                if (_allColors[1] == value) return;
                _allColors[1] = value;
            }
        }

        public Color[,] RightColors
        {
            get { return _allColors[2]; }
            private set
            {
                if (_allColors[2] == value) return;
                _allColors[2] = value;
            }
        }

        public Color[,] LeftColors
        {
            get { return _allColors[3]; }
            private set
            {
                if (_allColors[3] == value) return;
                _allColors[3] = value;
            }
        }

        public Color[,] UpColors
        {
            get { return _allColors[4]; }
            private set
            {
                if (_allColors[4] == value) return;
                _allColors[4] = value;
            }
        }

        public Color[,] DownColors
        {
            get { return _allColors[5]; }
            private set
            {
                if (_allColors[5] == value) return;
                _allColors[5] = value;
            }
        }

        /// <summary>
        /// Gets whether the cube has valid, solvable color quantities.
        /// The cube needs 9 of 6 distinct colors
        /// </summary>
        public bool HasValidColorQuantities
        {
            get
            {
                var scheme = GetColorScheme();
                int frontCount = 0;
                int backCount = 0;
                int rightCount = 0;
                int leftCount = 0;
                int upCount = 0;
                int downCount = 0;
                var colors = GetColorsFlattened();

                foreach (Color color in colors)
                {
                    if (color.RgbEquals(scheme.FrontColor)) frontCount++;
                    else if (color.RgbEquals(scheme.BackColor)) backCount++;
                    else if (color.RgbEquals(scheme.RightColor)) rightCount++;
                    else if (color.RgbEquals(scheme.LeftColor)) leftCount++;
                    else if (color.RgbEquals(scheme.UpColor)) upCount++;
                    else if (color.RgbEquals(scheme.DownColor)) downCount++;
                }

                return (frontCount == 6 && backCount == 6 && rightCount == 6 &&
                        leftCount == 6 && upCount == 6 && downCount == 6);
            }
        }

        /// <summary>
        /// Gets whether this cube is solved
        /// </summary>
        public bool Solved
        {
            get
            {
                // Iterate all faces and check to see if they consist of one color
                foreach (var array in AllColors)
                {
                    Color lastColor = array[0, 0];

                    foreach (var color in array)
                    {
                        if (lastColor != color) return false;
                    }
                }

                return true;
            }
        }
        #endregion

        /// <summary>
        /// Creates an instance of the RubiksCube
        /// </summary>
        /// <param name="colors">Face arrays are as follows:
        /// Front 0, Back 1, Right 2, left 3, Up 4, Down 5</param>
        public RubiksCube(Color[][,] colors)
        {
            _origColors = CloneColors(colors);
            // Clone so we dont modify the original matrix
            _allColors = colors;
        }

        /// <summary>
        /// Occurs when a single move has been made
        /// </summary>
        public event EventHandler<CubeMove> MoveMade;
        /// <summary>
        /// Raises the MoveMade event
        /// </summary>
        protected virtual void OnMoveMade(CubeMove move)
        {
            if (MoveMade != null)
                MoveMade(this, move);
        }

        /// <summary>
        /// Resets the colors to the cubes unmodified state
        /// </summary>
        public void Restore()
        {
            // Clone original so we do not modify it
            _allColors = CloneColors(_origColors);
        }

        /// <summary>
        /// Creates a solved cube from a specified color scheme
        /// </summary>
        public static RubiksCube Create(CubeColorScheme scheme)
        {
            var colors = new Color[6][,];
            colors[0] = CreateFace(scheme.FrontColor);
            colors[1] = CreateFace(scheme.BackColor);
            colors[2] = CreateFace(scheme.RightColor);
            colors[3] = CreateFace(scheme.LeftColor);
            colors[4] = CreateFace(scheme.UpColor);
            colors[5] = CreateFace(scheme.DownColor);
            return new RubiksCube(colors);
        }

        /// <summary>
        /// Gets the color scheme for this cube
        /// </summary>
        public CubeColorScheme GetColorScheme()
        {
            return new CubeColorScheme(
                FrontColors[1, 1],
                BackColors[1, 1],
                RightColors[1, 1],
                LeftColors[1, 1],
                UpColors[1, 1],
                DownColors[1, 1]);
        }

        /// <summary>
        /// Creates and returns a ColorDefect based on the current state of the cube
        /// </summary>
        public ColorDefect GetColorDefects()
        {
            // Find redundant face colors
            var faceColors = GetColorScheme().All;
            Stack<Color> invalidFaceColors = new Stack<Color>();
            foreach (Color color in faceColors)
            {
                if (faceColors.Count(c => c == color) > 1 &&
                    !invalidFaceColors.Contains(color))
                {
                    invalidFaceColors.Push(color);
                }
            }
      
            // Find colors occuring more than 9 times
            var scheme = GetColorScheme();
            int frontCount = 0;
            int backCount = 0;
            int rightCount = 0;
            int leftCount = 0;
            int upCount = 0;
            int downCount = 0;
            var colors = GetColorsFlattened();

            foreach (Color color in colors)
            {
                if (color.RgbEquals(scheme.FrontColor)) frontCount++;
                else if (color.RgbEquals(scheme.BackColor)) backCount++;
                else if (color.RgbEquals(scheme.RightColor)) rightCount++;
                else if (color.RgbEquals(scheme.LeftColor)) leftCount++;
                else if (color.RgbEquals(scheme.UpColor)) upCount++;
                else if (color.RgbEquals(scheme.DownColor)) downCount++;
            }

            var excessiveColors = new List<Color>();
            if (frontCount > 9) excessiveColors.Add(scheme.FrontColor);
            if (backCount > 9) excessiveColors.Add(scheme.BackColor);
            if (leftCount > 9) excessiveColors.Add(scheme.LeftColor);
            if (rightCount > 9) excessiveColors.Add(scheme.RightColor);
            if (upCount > 9) excessiveColors.Add(scheme.UpColor);
            if (downCount > 9) excessiveColors.Add(scheme.DownColor);

            // Calculate whether there are too many distinct colors in cube
            bool redundantDistinct = (GetColorsFlattened().Distinct().Count() > 6);

            return new ColorDefect(excessiveColors.ToArray(),
                invalidFaceColors.ToArray(), redundantDistinct); 
        }

        /// <summary>
        /// Reset the cube to its solved state
        /// </summary>
        public void CleanSlate()
        {
            var cube = Create(GetColorScheme());
            _allColors = cube._allColors;
        }

        /// <summary>
        /// Creates a 3x3 face with a solid color
        /// </summary>
        public static Color[,] CreateFace(Color faceColor)
        {
            return new[,]
            {
               {faceColor, faceColor, faceColor},
               {faceColor, faceColor, faceColor},
               {faceColor, faceColor, faceColor}
            };
        }
        /// <summary>
        /// Gets a cube face from the CubeSide specified
        /// </summary>
        /// <returns>Null, if CubeSide.None specified</returns>
        private Color[,] GetFaceColors(CubeSide side)
        {
            switch (side)
            {
                case CubeSide.Back: return BackColors;
                case CubeSide.Front: return FrontColors;
                case CubeSide.Left: return LeftColors;
                case CubeSide.Right: return RightColors;
                case CubeSide.Up: return UpColors;
                case CubeSide.Down: return DownColors;
                default: return null;
            }
        }

        /// <summary>
        /// Sets the colors for the cube side specified
        /// </summary>
        private void SetSide(CubeSide side, Color[,] value)
        {
            switch (side)
            {
                case CubeSide.Back: BackColors = value; break;
                case CubeSide.Front: FrontColors = value; break;
                case CubeSide.Left: LeftColors = value; break;
                case CubeSide.Right: RightColors = value; break;
                case CubeSide.Up: UpColors = value; break;
                case CubeSide.Down: DownColors = value; break;
            }
        }

        /// <summary>
        /// Rotates the colors only on the surface of the side
        /// </summary>
        private void RotateFace(CubeSide side, Rotation rotation)
        {
            var faceToRotate = GetFaceColors(side);
            var newFace = new Color[3, 3];

            if (rotation == Rotation.Cw)
            {
                for (int i = 2; i >= 0; i--)
                    for (int i2 = 0; i2 < 3; i2++)
                        newFace[i2, 2 - i] = faceToRotate[i, i2];
            }
            else
            {
                for (int i = 2; i >= 0; i--)
                    for (int i2 = 0; i2 < 3; i2++)
                        newFace[2 - i, i2] = faceToRotate[i2, i];
            }

            SetSide(side, newFace);
        }

        /// <summary>
        /// Gets the color matrix colors as a flat color array
        /// </summary>
        public IEnumerable<Color> GetColorsFlattened()
        {
            var colorStack = new Stack<Color>();

            foreach (Color[,] array in _allColors)
            {
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    for (int clm = 0; clm < array.GetLength(1); clm++)
                        colorStack.Push(array[row, clm]);
                }
            }

            return colorStack;
        }


        private static Color[][,] CloneColors(Color[][,] source)
        {
            var cloned = new Color[source.Length][,];

            // Iterate array
            for (int i = 0; i < source.Length; i++)
            {
                cloned[i] = new Color[3, 3];

                for (int row = 0; row < source[i].GetLength(0); row++)
                {
                    for (int clm = 0; clm < source[i].GetLength(1); clm++)
                    {
                        cloned[i][row, clm] = source[i][row, clm];
                    }
                }
            }

            return cloned;
        }

        public void MakeMove(CubeMove move)
        {
            MakeMove(move.Side, move.Rotation);
        }

        /// <summary>
        /// Makes a move from one or more algorithms
        /// </summary>
        public void MakeMove(params Algorithm[] algorithms)
        {
            foreach (var algorithm in algorithms)
            {
                switch (algorithm)
                {
                    case Algorithm.F:  MakeMove(CubeSide.Front, Rotation.Cw); break;
                    case Algorithm.Fi: MakeMove(CubeSide.Front, Rotation.Ccw); break;
                    case Algorithm.B:  MakeMove(CubeSide.Back, Rotation.Cw); break;
                    case Algorithm.Bi: MakeMove(CubeSide.Back, Rotation.Ccw); break;
                    case Algorithm.U:  MakeMove(CubeSide.Up, Rotation.Cw); break;
                    case Algorithm.Ui: MakeMove(CubeSide.Up, Rotation.Ccw); break;
                    case Algorithm.D:  MakeMove(CubeSide.Down, Rotation.Cw); break;
                    case Algorithm.Di: MakeMove(CubeSide.Down, Rotation.Ccw); break;
                    case Algorithm.L:  MakeMove(CubeSide.Left, Rotation.Cw); break;
                    case Algorithm.Li: MakeMove(CubeSide.Left, Rotation.Ccw); break;
                    case Algorithm.R:  MakeMove(CubeSide.Right, Rotation.Cw); break;
                    case Algorithm.Ri: MakeMove(CubeSide.Right, Rotation.Ccw); break;
                    default:
                        throw new ArgumentException("Imvalid enum specified", "algorithms");
                }
            }
        }

        public void MakeMove(CubeSide side, Rotation rotation)
        {
            if (side == CubeSide.None) return;
            RotateFace(side, rotation);
            // Rotate non-face colors
            // No need to set middle colors as newColors is a full copy
            var newColors = CloneColors(_allColors);

            switch (side)
            {
                #region Front Shift
                case CubeSide.Front:

                    if (rotation == Rotation.Cw)
                    {
                        // Shift Left to up
                        newColors[4][2, 0] = LeftColors[2, 2];
                        newColors[4][2, 1] = LeftColors[1, 2];
                        newColors[4][2, 2] = LeftColors[0, 2];
                        // Shift up to right
                        newColors[2][0, 0] = UpColors[2, 0];
                        newColors[2][1, 0] = UpColors[2, 1];
                        newColors[2][2, 0] = UpColors[2, 2];
                        // Shift right to down
                        newColors[5][0, 2] = RightColors[0, 0];
                        newColors[5][0, 1] = RightColors[1, 0];
                        newColors[5][0, 0] = RightColors[2, 0];
                        // Shift down to left
                        newColors[3][0, 2] = DownColors[0, 0];
                        newColors[3][1, 2] = DownColors[0, 1];
                        newColors[3][2, 2] = DownColors[0, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to left
                        newColors[3][2, 2] = UpColors[2, 0];
                        newColors[3][1, 2] = UpColors[2, 1];
                        newColors[3][0, 2] = UpColors[2, 2];
                        // Shift right to up
                        newColors[4][2, 0] = RightColors[0, 0];
                        newColors[4][2, 1] = RightColors[1, 0];
                        newColors[4][2, 2] = RightColors[2, 0];
                        // Shift down to right
                        newColors[2][0, 0] = DownColors[0, 2];
                        newColors[2][1, 0] = DownColors[0, 1];
                        newColors[2][2, 0] = DownColors[0, 0];
                        // Shift left to down
                        newColors[5][0, 0] = LeftColors[0, 2];
                        newColors[5][0, 1] = LeftColors[1, 2];
                        newColors[5][0, 2] = LeftColors[2, 2];
                    }

                    break;
                #endregion

                #region Back Shift
                case CubeSide.Back:

                    if (rotation == Rotation.Ccw)
                    {
                        // Shift Left to up
                        newColors[4][0, 0] = LeftColors[2, 0];
                        newColors[4][0, 1] = LeftColors[1, 0];
                        newColors[4][0, 2] = LeftColors[0, 0];
                        // Shift up to right
                        newColors[2][0, 2] = UpColors[0, 0];
                        newColors[2][1, 2] = UpColors[0, 1];
                        newColors[2][2, 2] = UpColors[0, 2];
                        // Shift right to down
                        newColors[5][2, 2] = RightColors[0, 2];
                        newColors[5][2, 1] = RightColors[1, 2];
                        newColors[5][2, 0] = RightColors[2, 2];
                        // Shift down to left
                        newColors[3][0, 0] = DownColors[2, 0];
                        newColors[3][1, 0] = DownColors[2, 1];
                        newColors[3][2, 0] = DownColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to left
                        newColors[3][2, 0] = UpColors[0, 0];
                        newColors[3][1, 0] = UpColors[0, 1];
                        newColors[3][0, 0] = UpColors[0, 2];
                        // Shift right to up
                        newColors[4][0, 0] = RightColors[0, 2];
                        newColors[4][0, 1] = RightColors[1, 2];
                        newColors[4][0, 2] = RightColors[2, 2];
                        // Shift down to right
                        newColors[2][0, 2] = DownColors[2, 2];
                        newColors[2][1, 2] = DownColors[2, 1];
                        newColors[2][2, 2] = DownColors[2, 0];
                        // Shift left to down
                        newColors[5][2, 0] = LeftColors[0, 0];
                        newColors[5][2, 1] = LeftColors[1, 0];
                        newColors[5][2, 2] = LeftColors[2, 0];
                    }

                    break;
                #endregion

                #region Right Shift
                case CubeSide.Right:

                    if (rotation == Rotation.Cw)
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to up
                        newColors[4][0, 2] = FrontColors[0, 2];
                        newColors[4][1, 2] = FrontColors[1, 2];
                        newColors[4][2, 2] = FrontColors[2, 2];
                        // Shift up to back
                        newColors[1][2, 0] = UpColors[0, 2];
                        newColors[1][1, 0] = UpColors[1, 2];
                        newColors[1][0, 0] = UpColors[2, 2];
                        // Shift back to down
                        newColors[5][0, 2] = BackColors[2, 0];
                        newColors[5][1, 2] = BackColors[1, 0];
                        newColors[5][2, 2] = BackColors[0, 0];
                        // Shift down to front
                        newColors[0][0, 2] = DownColors[0, 2];
                        newColors[0][1, 2] = DownColors[1, 2];
                        newColors[0][2, 2] = DownColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to front
                        newColors[0][0, 2] = UpColors[0, 2];
                        newColors[0][1, 2] = UpColors[1, 2];
                        newColors[0][2, 2] = UpColors[2, 2];
                        // Shift back to up
                        newColors[4][0, 2] = BackColors[2, 0];
                        newColors[4][1, 2] = BackColors[1, 0];
                        newColors[4][2, 2] = BackColors[0, 0];
                        // Shift down to back
                        newColors[1][0, 0] = DownColors[2, 2];
                        newColors[1][1, 0] = DownColors[1, 2];
                        newColors[1][2, 0] = DownColors[0, 2];
                        // Shift front to down
                        newColors[5][0, 2] = FrontColors[0, 2];
                        newColors[5][1, 2] = FrontColors[1, 2];
                        newColors[5][2, 2] = FrontColors[2, 2];
                    }

                    break;
                #endregion

                #region Left Shift
                case CubeSide.Left:

                    if (rotation == Rotation.Cw)
                    {
                        // Shift up to front
                        newColors[0][0, 0] = UpColors[0, 0];
                        newColors[0][1, 0] = UpColors[1, 0];
                        newColors[0][2, 0] = UpColors[2, 0];
                        // Shift front to down
                        newColors[5][0, 0] = FrontColors[0, 0];
                        newColors[5][1, 0] = FrontColors[1, 0];
                        newColors[5][2, 0] = FrontColors[2, 0];
                        // Shift down to back
                        newColors[1][2, 2] = DownColors[0, 0];
                        newColors[1][1, 2] = DownColors[1, 0];
                        newColors[1][0, 2] = DownColors[2, 0];
                        // Shift back to up
                        newColors[4][2, 0] = BackColors[0, 2];
                        newColors[4][1, 0] = BackColors[1, 2];
                        newColors[4][0, 0] = BackColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to up
                        newColors[4][0, 0] = FrontColors[0, 0];
                        newColors[4][1, 0] = FrontColors[1, 0];
                        newColors[4][2, 0] = FrontColors[2, 0];
                        // Shift down to front
                        newColors[0][0, 0] = DownColors[0, 0];
                        newColors[0][1, 0] = DownColors[1, 0];
                        newColors[0][2, 0] = DownColors[2, 0];
                        // Shift back to down
                        newColors[5][0, 0] = BackColors[2, 2];
                        newColors[5][1, 0] = BackColors[1, 2];
                        newColors[5][2, 0] = BackColors[0, 2];
                        // Shift up to back
                        newColors[1][0, 2] = UpColors[2, 0];
                        newColors[1][1, 2] = UpColors[1, 0];
                        newColors[1][2, 2] = UpColors[0, 0];
                    }

                    break;
                #endregion

                #region Up Shift
                case CubeSide.Up:

                    // Rotate outercolors
                    if (rotation == Rotation.Cw)
                    {
                        // No need to set middle colors as newColors is a full copy
                        // Shift right to front
                        newColors[0][0, 0] = RightColors[0, 0];
                        newColors[0][0, 1] = RightColors[0, 1];
                        newColors[0][0, 2] = RightColors[0, 2];
                        // Shift front to left
                        newColors[3][0, 0] = FrontColors[0, 0];
                        newColors[3][0, 1] = FrontColors[0, 1];
                        newColors[3][0, 2] = FrontColors[0, 2];
                        // Shift left to back
                        newColors[1][0, 0] = LeftColors[0, 0];
                        newColors[1][0, 1] = LeftColors[0, 1];
                        newColors[1][0, 2] = LeftColors[0, 2];
                        // Shift back to right
                        newColors[2][0, 0] = BackColors[0, 0];
                        newColors[2][0, 1] = BackColors[0, 1];
                        newColors[2][0, 2] = BackColors[0, 2];
                    }
                    else
                    {
                        //  0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to right
                        newColors[2][0, 0] = FrontColors[0, 0];
                        newColors[2][0, 1] = FrontColors[0, 1];
                        newColors[2][0, 2] = FrontColors[0, 2];
                        // Shift left to front
                        newColors[0][0, 0] = LeftColors[0, 0];
                        newColors[0][0, 1] = LeftColors[0, 1];
                        newColors[0][0, 2] = LeftColors[0, 2];
                        // Shift back to left
                        newColors[3][0, 0] = BackColors[0, 0];
                        newColors[3][0, 1] = BackColors[0, 1];
                        newColors[3][0, 2] = BackColors[0, 2];
                        // Shift right to back
                        newColors[1][0, 0] = RightColors[0, 0];
                        newColors[1][0, 1] = RightColors[0, 1];
                        newColors[1][0, 2] = RightColors[0, 2];
                    }
                    break;
                #endregion

                #region Down Shift
                case CubeSide.Down:

                    // Rotate outercolors
                    if (rotation == Rotation.Ccw)
                    {
                        //  0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift right to front
                        newColors[0][2, 0] = RightColors[2, 0];
                        newColors[0][2, 1] = RightColors[2, 1];
                        newColors[0][2, 2] = RightColors[2, 2];
                        // Shift front to left
                        newColors[3][2, 0] = FrontColors[2, 0];
                        newColors[3][2, 1] = FrontColors[2, 1];
                        newColors[3][2, 2] = FrontColors[2, 2];
                        // Shift left to back
                        newColors[1][2, 0] = LeftColors[2, 0];
                        newColors[1][2, 1] = LeftColors[2, 1];
                        newColors[1][2, 2] = LeftColors[2, 2];
                        // Shift back to right
                        newColors[2][2, 0] = BackColors[2, 0];
                        newColors[2][2, 1] = BackColors[2, 1];
                        newColors[2][2, 2] = BackColors[2, 2];
                    }
                    else
                    {
                        // Shift front to right
                        newColors[2][2, 0] = FrontColors[2, 0];
                        newColors[2][2, 1] = FrontColors[2, 1];
                        newColors[2][2, 2] = FrontColors[2, 2];
                        // Shift left to front
                        newColors[0][2, 0] = LeftColors[2, 0];
                        newColors[0][2, 1] = LeftColors[2, 1];
                        newColors[0][2, 2] = LeftColors[2, 2];
                        // Shift back to left
                        newColors[3][2, 0] = BackColors[2, 0];
                        newColors[3][2, 1] = BackColors[2, 1];
                        newColors[3][2, 2] = BackColors[2, 2];
                        // Shift right to back
                        newColors[1][2, 0] = RightColors[2, 0];
                        newColors[1][2, 1] = RightColors[2, 1];
                        newColors[1][2, 2] = RightColors[2, 2];
                    }
                    break;
                #endregion
            }

            _allColors = newColors;

            if (_raiseEvents)
                OnMoveMade(new CubeMove(side, rotation));
        }

        /// <summary>
        /// Creates a new RubiksCube from this instance
        /// </summary>
        public object Clone()
        {
            var colors = CloneColors(_allColors);
            return new RubiksCube(colors);
        }
    }
}
