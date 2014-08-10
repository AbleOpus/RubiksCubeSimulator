using System;
using System.Drawing;
using System.Windows.Forms;

namespace RubiksCubeSimulator
{
    static class ExtensionMethods
    {
        public static Color Desaturate(this Color color)
        {
            var b = (int)(255 * color.GetBrightness());
            return Color.FromArgb(b, b, b);
        }

        public static Color ChangeBrightness(this Color color, int factor)
        {
            int R = (color.R + factor > 255) ? 255 : color.R + factor;
            int G = (color.G + factor > 255) ? 255 : color.G + factor;
            int B = (color.B + factor > 255) ? 255 : color.B + factor;

            R = (color.R + factor < 0) ? 0 : R;
            G = (color.G + factor < 0) ? 0 : G;
            B = (color.B + factor < 0) ? 0 : B;

            return Color.FromArgb(R, G, B);
        }

        public static Rectangle ToRect(this RectangleF rectF)
        {
            return new Rectangle((int)(rectF.X + 0.5), (int)(rectF.Y + 0.5),
            (int)(rectF.Width + 0.5), (int)(rectF.Height + 0.5));
        }

        /// <summary>
        /// Shows a typical error message box with an error icon and the applications
        /// product name as the title
        /// </summary>
        public static void ShowMessage(this Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Compares two colors using there RGB value (and not their names)
        /// </summary>
        public static bool RgbEquals(this Color c, Color color)
        {
            return (color.R == c.R && color.G == c.G && color.B == c.B);
        } 
    }
}
