using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EasyGraph
{
    class Utilities
    {

        public static bool isContinue = true;

        public static List<double> Random(string text, Random random)
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

        private static List<double> CheckingInputText(string inputText)
        {
            List<double> inputList = new List<double>();

            if (inputText.Contains(":"))
                inputList = Utilities.Parser(inputText);

            else if (inputText.Contains("random"))
                inputList = Utilities.Random(inputText, Config.random);

            else if (inputText.Contains("[") && inputText.Contains("]"))
            {
                int count = 0;
                foreach (Match m in Regex.Matches(inputText, "]"))
                    count++;
                if (count >= 2) return inputList;

                inputText = inputText.Replace(" ", "");
                inputText = inputText.Replace("[", "");
                inputText = inputText.Replace("]", "");

                foreach (string i in inputText.Split(new char[] { '\n', ',' }))
                    inputList.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));
            }
            return inputList;
        }

        public static List<double> CheckingXinput(string xInputText)
        {
            List<double> xList = new List<double>();

            xList = CheckingInputText(xInputText);
            if (xList.Count == 0)
            {
                if (xInputText.Contains("[") && xInputText.Contains("]"))
                {
                    xInputText = xInputText.Replace(" ", "");
                    xInputText = xInputText.Replace("[", "");
                    xInputText = xInputText.Replace("]", "");

                    foreach (string i in xInputText.Split(new char[] { '\n', ',' }))
                        xList.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));

                }
                return xList;
            }
            else
                return xList;
        }
        public static List<string> CheckingYinput(string yInputText)
        {
            List<string> yList = new List<string>();

            if (CheckingInputText(yInputText).Count != 0)
                yList.Add(string.Join(" ", CheckingInputText(yInputText)));
            else if (yInputText.Contains("[") && yInputText.Contains("]"))
            {
                int lineNumber = 0;
                yInputText = yInputText.Replace(" ", "");
                yInputText = yInputText.Replace("[", "");

                foreach (string value in yInputText.Split(']'))
                {
                    if (value == "") continue;
                    Config.nameLines.Add(Config.LanguageLocale[7] + $" {lineNumber}");
                    yList.Add(value);
                    lineNumber++;
                }
            }
            return yList;
        }
    }
}
