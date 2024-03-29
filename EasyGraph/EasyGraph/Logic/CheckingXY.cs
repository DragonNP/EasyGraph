﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EasyGraph.Logic.MainLogic;

namespace EasyGraph
{
    class CheckingXY
    {
        private static readonly Random random = new Random();

        private static List<double> Parser(string text)
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
                IsContinue = false;
                return null;
            }
        }

        private static List<double> Random(string text, Random random)
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

        private static List<double> CheckingInputText(string inputText)
        {
            List<double> inputList = new List<double>();

            if (inputText.Contains(":"))
                inputList = Parser(inputText);
            else if (inputText.Contains("random"))
                inputList = Random(inputText, random);
            return inputList;
        }

        public static List<double> CheckingXinput(string xInputText)
        {
            List<double> xList = CheckingInputText(xInputText);
            if (xList.Count != 0) return xList;
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

        public static List<string> CheckingYinput(string yInputText)
        {
            List<string> yList = new List<string>();
            List<double> chekingList = CheckingInputText(yInputText);
            if (chekingList.Count != 0)  yList.Add(string.Join(",", chekingList));
            else if (yInputText.Contains("[") && yInputText.Contains("]"))
            {
                int lineNumber = 0;
                yInputText = yInputText.Replace(" ", "");
                yInputText = yInputText.Replace("]", "");
                foreach (string value in yInputText.Split('['))
                {
                    if (value == "") continue;
                    Config.nameLines.Add(Config.LanguageLocale[6] + $" {lineNumber}");
                    yList.Add(value);
                    lineNumber++;
                }
            }
            return yList;
        }
    }
}
