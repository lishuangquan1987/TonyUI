using System;
using System.Windows.Media;

namespace TonyUI.Helpers
{
    public struct HslColor
    {
        public double H { get; }
        public double S { get; }
        public double L { get; }
        public double A { get; }

        public HslColor(double h, double s, double l, double a = 1.0)
        {
            H = h;
            S = s;
            L = l;
            A = a;
        }

        public Color ToColor()
        {
            double r, g, b;

            if (S == 0)
            {
                r = g = b = L;
            }
            else
            {
                double q = L < 0.5 ? L * (1 + S) : L + S - L * S;
                double p = 2 * L - q;

                r = HueToRgb(p, q, H + 1.0 / 3.0);
                g = HueToRgb(p, q, H);
                b = HueToRgb(p, q, H - 1.0 / 3.0);
            }

            return Color.FromArgb(
                (byte)(A * 255),
                (byte)(r * 255),
                (byte)(g * 255),
                (byte)(b * 255)
            );
        }

        private static double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }

        public static HslColor FromColor(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double h, s, l = (max + min) / 2;

            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h /= 6;
            }

            return new HslColor(h, s, l, color.A / 255.0);
        }

        public override string ToString()
        {
            return $"HSL({H * 360:F0}, {S * 100:F0}%, {L * 100:F0}%)";
        }
    }
}
