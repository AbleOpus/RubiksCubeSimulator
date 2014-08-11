using System;
using System.Drawing;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a color layout for a rubiks cube
    /// </summary>
    class CubeColorScheme
    {
        public readonly static CubeColorScheme DevsScheme = new CubeColorScheme
            (Color.White, Color.Yellow, Color.Red, Color.Orange, Color.Blue, Color.Green);

        #region Properties
        /// <summary>
        /// Gets the top color of the cube
        /// </summary>
        public Color UpColor { get; private set; }

        /// <summary>
        /// Gets the bottom color of the cube
        /// </summary>
        public Color DownColor { get; private set; }

        /// <summary>
        /// Gets the left color of the cube
        /// </summary>
        public Color LeftColor { get; private set; }

        /// <summary>
        /// Gets the right color of the cube
        /// </summary>
        public Color RightColor { get; private set; }

        /// <summary>
        /// Gets the front color of the cube
        /// </summary>
        public Color FrontColor { get; private set; }

        /// <summary>
        /// Gets the back color of the cube
        /// </summary>
        public Color BackColor { get; private set; }

        /// <summary>
        /// Gets all of the face colors
        /// </summary>
        public Color[] All
        {
            get
            {
                return new Color[] { UpColor, DownColor, RightColor, 
                    LeftColor, FrontColor, BackColor};
            }
        }
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
        /// Gets the color of the face specified
        /// </summary>
        public static Color FromFaceColors(Color[,] face)
        {
            return face[1, 1];
        }
    }
}
