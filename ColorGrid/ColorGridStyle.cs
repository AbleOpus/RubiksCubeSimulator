using System.Drawing;

namespace RubiksCubeSimulator.ColorGrid
{
    /// <summary>
    /// Represents parameters as required information for the ColorGridRenderer, which
    /// describe the appearance and layout of a color grid
    /// </summary>
    public class ColorGridStyle
    {
        /// <summary>
        /// Gets or sets the colors to be displayed on the grid
        /// </summary>
        public Color[,] Colors { get; set; }

        /// <summary>
        /// Gets or sets the relative thickness of the border pen
        /// </summary>
        public float CellSpacingScale { get; set; }

        /// <summary>
        /// Gets or sets the corner radius for the rounded rect used with the ColorGridRenderer
        /// </summary>
        public int RoundedRadius { get; set; }


        public ColorGridStyle(Color[,] colors, float cellSpacing, int roundedRadius)
        {
            Colors = colors;
            CellSpacingScale = cellSpacing;
            RoundedRadius = roundedRadius;
        }
    }
}
