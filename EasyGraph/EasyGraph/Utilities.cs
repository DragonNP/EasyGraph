using System;
using System.Collections.Generic;
using System.Drawing;

namespace EasyGraph
{
    class Utilities
    {
        public static string[] ColorArrayToStringArray()
        {
            List<string> stringColor = new List<string>();
            foreach (Color color in Config.LineColor)
                stringColor.Add($"{color.R}, {color.G}, {color.B}");

            return stringColor.ToArray();
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
