using System;
using System.Drawing;
using System.Linq;
using RubiksCubeSimulator.Rubiks;

namespace RubiksCubeSimulator
{
    [Serializable]
    class Settings : SettingsBase<Settings>
    {
        /// <summary>
        /// Gets or sets the colors to pick from
        /// </summary>
        public Color[] Palette { get; set; }

        /// <summary>
        /// Gets or sets the last set cube colors
        /// </summary>
        public Color[][,] CubeColors { get; set; }

        /// <summary>
        /// Gets or sets whether the color strip is locked
        /// </summary>
        public bool ColorsLocked { get; set; }

        public override void Reset()
        {
            var tempCube = RubiksCube.Create(CubeColorScheme.DevsScheme);
            CubeColors = tempCube.AllColors;
            Palette = tempCube.GetColorsFlattened().Distinct().ToArray();
        }
    }
}
