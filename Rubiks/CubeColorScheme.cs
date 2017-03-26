using System;
using System.Drawing;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a color layout for a rubiks cube.
    /// </summary>
    class CubeColorScheme
    {
        /// <summary>
        /// The developers physical cube color scheme.
        /// </summary>
        public static readonly CubeColorScheme DevsScheme = new CubeColorScheme
            (Color.White, Color.Yellow, Color.Red, Color.Orange, Color.Blue, Color.Green);

        #region Properties
        /// <summary>
        /// Gets the top color of the cube.
        /// </summary>
        public Color UpColor { get; }

        /// <summary>
        /// Gets the bottom color of the cube.
        /// </summary>
        public Color DownColor { get; }

        /// <summary>
        /// Gets the left color of the cube.
        /// </summary>
        public Color LeftColor { get; }

        /// <summary>
        /// Gets the right color of the cube.
        /// </summary>
        public Color RightColor { get; }

        /// <summary>
        /// Gets the front color of the cube.
        /// </summary>
        public Color FrontColor { get; }

        /// <summary>
        /// Gets the back color of the cube.
        /// </summary>
        public Color BackColor { get; }

        /// <summary>
        /// Gets all of the face colors.
        /// </summary>
        public Color[] All => 
            new[] { UpColor, DownColor, RightColor, LeftColor, FrontColor, BackColor};

        #endregion

        public CubeColorScheme(Color frontColor, Color backColor, Color rightColor,
            Color leftColor, Color upColor, Color downColor)
        {
            FrontColor = frontColor;
            BackColor = backColor;
            RightColor = rightColor;
            LeftColor = leftColor;
            UpColor = upColor;
            DownColor = downColor;
        }

        /// <summary>
        /// Gets the color of the face specified.
        /// </summary>
        public static Color FromFaceColors(Color[,] face)
        {
            return face[1, 1];
        }
    }
}
