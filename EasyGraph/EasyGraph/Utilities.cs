using System;
using System.Drawing;

namespace EasyGraph
{
    class Utilities
    {
        public static string ColorToString(Color color)
        {
            return $"{color.R}, {color.G}, {color.B}";
        }

        public static Color StringToColor(string str)
        {
            str = str.Replace(" ", "");
            int r, g, b;
            string[] strArr = str.Split(',');
            r = Convert.ToInt32(strArr[0]);
            g = Convert.ToInt32(strArr[1]);
            b = Convert.ToInt32(strArr[2]);
            return Color.FromArgb(r, g, b);
        }
    }
}
