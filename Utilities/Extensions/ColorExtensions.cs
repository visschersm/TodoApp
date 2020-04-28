using System.Drawing;
using System.Globalization;

// https://stackoverflow.com/questions/2109756/how-do-i-get-the-color-from-a-hexadecimal-color-code-using-net

namespace MTech.Utilities.Extensions
{
    public static class ColorExtensions
    {
        public static string ToHtml(this Color source)
        {
            return $"#{source.R:X2}{source.G:X2}{source.B:X2}";
        }

        public static Color ToColor(this string source)
        {
            Color col; // from System.Drawing or System.Windows.Media
            if (source.Length == 6)
            {
                col = Color.FromArgb(255, // hardcoded opaque
                            int.Parse(source.Substring(0, 2), NumberStyles.HexNumber),
                            int.Parse(source.Substring(2, 2), NumberStyles.HexNumber),
                            int.Parse(source.Substring(4, 2), NumberStyles.HexNumber));
            }
            else // assuming length of 8
            {
                col = Color.FromArgb(
                            int.Parse(source.Substring(0, 2), NumberStyles.HexNumber),
                            int.Parse(source.Substring(2, 2), NumberStyles.HexNumber),
                            int.Parse(source.Substring(4, 2), NumberStyles.HexNumber),
                            int.Parse(source.Substring(6, 2), NumberStyles.HexNumber));
            }

            return col;
        }

        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        public static string ToRgbString(this Color c) => $"RGB({c.R}, {c.G}, {c.B})";
    }
}
