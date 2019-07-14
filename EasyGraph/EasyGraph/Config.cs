using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGraph
{
    public static class Config
    {
        public static string PathRegistry { get; set; } = "Software\\EasyGraph";

        public static Font font = new Font("Arial", 12, FontStyle.Regular);

        public static string Show_values { get; set; } = "Show values";

        public static string Options { get; set; } = "Options";

        public static string LanguageMenuStrip { get; set; } = "Language";

        public static string Donation { get; set; } = "Donation";

        public static string Build { get; set; } = "Build";

        public static string Graph { get; set; } = "Graph";

        public static string Legend { get; set; } = "Legend";

        public static string Line { get; set; } = "Line";

    }

}
