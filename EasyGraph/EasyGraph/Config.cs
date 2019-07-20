using System.Collections.Generic;
using System.Drawing;

namespace EasyGraph
{
    public static class Config
    {
        public static string PathRegistry { get; set; } = "Software\\EasyGraph";

        public static Font font = new Font("Arial", 12, FontStyle.Regular);

        public static List<string> LanguageLocale = new List<string>();

        public static List<string> nameLines = new List<string>();

        public static List<Color> LineColor = new List<Color>() {
            Color.Black,
            Color.Chocolate,
            Color.Red,
            Color.Blue,
            Color.BurlyWood,
            Color.Beige,
            Color.Aqua,
            Color.Beige,
            Color.Brown,
            Color.CadetBlue
        };
    }
}
