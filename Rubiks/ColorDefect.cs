using System.Drawing;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents information about potential rubiks cube color defects
    /// </summary>
    class ColorDefect
    {
        /// <summary>
        /// Gets the colors that are defective. This will only contain
        /// colors that have too many occurences
        /// </summary>
        public Color[] Colors { get; private set; }

        /// <summary>
        /// Gets the type of color defect
        /// </summary>
        public ColorDefectType Type { get; private set; }

        public ColorDefect(Color[] colors, ColorDefectType type)
        {
            Type = type;
            Colors = colors ?? new Color[] { };
        }
    }
}
