using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyGraph
{
    class Utilities
    {
        private readonly static Random random = new Random();
        public static bool isContinue = true;

        public static List<double> Random(string text)
        {

            double min, max, col;
            text = text.Replace(" ", "");
            text = text.Replace("random(", "");
            text = text.Replace(")", "");
            string[] str = text.Split(',');
            List<double> list = new List<double>();

            min = double.Parse(str[0], System.Globalization.CultureInfo.InvariantCulture);
            max = double.Parse(str[1], System.Globalization.CultureInfo.InvariantCulture);
            col = double.Parse(str[2], System.Globalization.CultureInfo.InvariantCulture);

            for (int i = 0; i <= col; i++)
                list.Add(Math.Round(random.NextDouble() * (max - min) + min, 2));
            return list;
        }

        public static List<double> Parser(string text)
        {
            double first, step, end;
            string[] str = text.Split(':');
            List<double> list = new List<double>();

            if (str.Length == 3)
            {
                first = double.Parse(str[0], System.Globalization.CultureInfo.InvariantCulture);
                step = double.Parse(str[1], System.Globalization.CultureInfo.InvariantCulture);
                end = double.Parse(str[2], System.Globalization.CultureInfo.InvariantCulture);

                for (double i = first; i <= end; i += step)
                    list.Add(i);
                return list;
            }
            else
            {
                MessageBox.Show(caption: "Error!",
                    text: "Wrong format!",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
                isContinue = false;
                return null;
            }
        }
    }
}
