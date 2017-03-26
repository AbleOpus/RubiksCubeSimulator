using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents information about potential rubiks cube color defects.
    /// </summary>
    internal class ColorDefect
    {
        /// <summary>
        /// Gets the colors that occur more than 9 times on the cube.
        /// </summary>
        public Color[] RedundantColors { get; }

        /// <summary>
        /// Gets all of the colors that are used for more than one face color.
        /// </summary>
        public Color[] RedundantFaceColors { get; }

        /// <summary>
        /// Gets whether there are more than 6 distinct colors.
        /// </summary>
        public bool TooManyDistinct { get; }

        public ColorDefect(Color[] redundantColors, Color[] redundantFaceColors, bool tooManyDistinct)
        {
            RedundantColors = redundantColors;
            RedundantFaceColors = redundantFaceColors;
            TooManyDistinct = tooManyDistinct;
        }

        private static string ColorArrayToString(IEnumerable<Color> colors)
        {
            var SB = new StringBuilder();

            foreach (Color color in colors)
                SB.Append(color.Name + ", ");

            SB.Remove(SB.Length - 2, 2);
            return SB.ToString();
        } 

        /// <summary>
        /// Gets a brief summarization of the first defect found.
        /// </summary>
        public string GetShortReport()
        {
            // There are too many instances of certain colors
            if (RedundantColors.Length > 0)
            {
                string colorString = ColorArrayToString(RedundantColors);
                return "There is too much of: " + colorString;
            }
            // There are too many distinct colors
            if (TooManyDistinct)
            {
                return "There are too many distinct colors";
            }

            if (RedundantFaceColors.Length > 0)
            {
                string colorString = ColorArrayToString(RedundantFaceColors);
                return "Face colors are invalid: " + colorString;
            }

            return string.Empty;
        }
    }
}
