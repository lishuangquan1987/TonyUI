using System.Windows.Media;

namespace TonyUI.Helpers
{
    public static class ColorExtensions
    {
        public static Color FromHsl(double h, double s, double l, double a = 1.0)
        {
            return new HslColor(h / 360.0, s / 100.0, l / 100.0, a).ToColor();
        }

        public static SolidColorBrush ToSolidBrush(this Color color)
        {
            return new SolidColorBrush(color);
        }

        public static SolidColorBrush ToSolidBrush(this HslColor hslColor)
        {
            return new SolidColorBrush(hslColor.ToColor());
        }
    }
}
