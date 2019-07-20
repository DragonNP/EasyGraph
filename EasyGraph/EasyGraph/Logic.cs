using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyGraph
{
    public static class Logic
    {
        private static readonly Random random = new Random();
        private static List<double> x = new List<double>();
        private static List<string> y = new List<string>();
        public static bool IsContinue { get; private set; } = true;
        public static List<List<DataPoint>> Points { get; set; } = new List<List<DataPoint>>();

        public static void Build_Chart(Form1 form1)
        {
            
            Config.nameLines.Clear();
            form1.TabControl.SelectedTab = form1.PageChart;

            x = CheckingXinput(xInputText: form1.xInput.Text);
            y = CheckingYinput(yInputText: form1.yInput.Text);

            if (IsContinue)
                form1.chart.PlotLine(x, y, nameLines: Config.nameLines);
        }

        public static void Save_Chart(Form1 form1)
        {
            form1.Save.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
            form1.Save.FileName = "Chart";
            if (form1.Save.ShowDialog() == DialogResult.Cancel)
                return;

            switch (form1.Save.FilterIndex)
            {
                case 1: form1.chart.SaveImage(form1.Save.FileName, ChartImageFormat.Bmp); break;
                case 2: form1.chart.SaveImage(form1.Save.FileName, ChartImageFormat.Png); break;
                case 3: form1.chart.SaveImage(form1.Save.FileName, ChartImageFormat.Jpeg); break;
            }
        }

        public static void Show_Values(Form1 form1)
        {
            if (x.Count == 0 || y.Count == 0) return;
            form1.TabControl.SelectedTab = form1.PageOuput;
            form1.output.Text = $"x = [{string.Join(" ", x)}]\n" +
                $"y = [{string.Join("][", y)}]";
        }

        #region Extensions for the chart

        public static void Initialize(
            this Chart chart, string title, string legendsTitle, Font font, string axisXTitle = "X",
            string axisYTitle = "Y", string areasName = "area", Color color = default,
            AxisArrowStyle axisArrowStyle = AxisArrowStyle.Triangle)
        {
            if (color.IsEmpty) color = Color.Black;

            chart.Titles.Add(title).Font = font;

            chart.Legends.Add(legendsTitle);
            chart.Legends[legendsTitle].Title = legendsTitle;
            chart.Legends[legendsTitle].TitleFont = font;

            chart.ChartAreas.Add(areasName);
            chart.ChartAreas[areasName].AxisX.Title = axisXTitle;
            chart.ChartAreas[areasName].AxisX.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisX.TitleFont = font;
            chart.ChartAreas[areasName].AxisX.TitleForeColor = color;

            chart.ChartAreas[areasName].AxisX2.Title = axisXTitle;
            chart.ChartAreas[areasName].AxisX2.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisX2.TitleFont = font;
            chart.ChartAreas[areasName].AxisX2.TitleForeColor = color;

            chart.ChartAreas[areasName].AxisY.Title = axisYTitle;
            chart.ChartAreas[areasName].AxisY.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisY.TitleFont = font;
            chart.ChartAreas[areasName].AxisY.TitleForeColor = color;

            chart.ChartAreas[areasName].AxisY2.Title = axisYTitle;
            chart.ChartAreas[areasName].AxisY2.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisY2.TitleFont = font;
            chart.ChartAreas[areasName].AxisY2.TitleForeColor = color;
        }

        public static void AddSeries(
            this Chart chart, List<string> nameLines, List<Color> colors, int borderWidth = 5, bool isClear = false,
            Font font = default, ChartDashStyle chartDashStyle = ChartDashStyle.Solid,
            SeriesChartType chartType = SeriesChartType.Line)
        {
            if (isClear)
                chart.Series.Clear();
            int nextColor = 0;
            foreach (string nameLine in nameLines)
            {
                chart.Series.Add(nameLine);
                chart.Series[nameLine].BorderDashStyle = chartDashStyle;
                chart.Series[nameLine].BorderWidth = borderWidth;
                chart.Series[nameLine].Color = colors[nextColor];
                chart.Series[nameLine].Font = font;
                chart.Series[nameLine].ChartType = chartType;
                chart.Update();
                if (nextColor == colors.Count) nextColor = 0;
                nextColor++;

            }
        }

        public static void AxisXY_Min_Max(
            this Chart chart, string areasName, double minX, double maxX, double minY,
            double maxY)
        {

            chart.ChartAreas[areasName].AxisX.Minimum = minX;
            chart.ChartAreas[areasName].AxisX.Maximum = maxX;

            chart.ChartAreas[areasName].AxisY.Minimum = minY;
            chart.ChartAreas[areasName].AxisY.Maximum = maxY;
        }
        
        public static void PlotLine(
            this Chart chart, List<double> x, List<string> y, List<string> nameLines)
        {
            double minX = -1, maxX = -1;
            double minY = -1, maxY = -1;

            Parallel.Invoke(
                () =>
                {
                    bool first = true;
                    foreach (string y1 in y)
                    {
                        List<string> yList = new List<string>();
                        yList.AddRange(y1.Split(new char[] { ',' }));
                        double buffer;
                        foreach (string y2 in yList)
                        {
                            buffer = double.Parse(y2, System.Globalization.CultureInfo.InvariantCulture);
                            if (first)
                            {
                                first = false;
                                minY = buffer;
                                maxY = buffer;
                            }
                            if (minY > buffer) minY = buffer;
                            else if (maxY < buffer) maxY = buffer;
                        }
                    }
                },
                () =>
                {
                    bool first = true;
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (first)
                        {
                            first = false;

                            minX = x[i];
                            maxX = x[i];
                        }
                        if (minX > x[i]) minX = x[i];
                        else if (maxX < x[i]) maxX = x[i];
                    }
                });

            Points.Clear();
            chart.AxisXY_Min_Max("area", minX, maxX, minY, maxY);
            chart.AddSeries(
                nameLines: nameLines,
                borderWidth: 3,
                font: Config.font,
                colors: Config.LineColor,
                isClear: true);

            int posPoint = 0;
            for (int i1 = 0; i1 < Config.nameLines.Count; i1++)
            {
                List<string> yList = new List<string>();
                yList.AddRange(y[i1].Split(new char[] { ',' }));
                Points.Add(new List<DataPoint>());

                for (int i2 = 0;
                    i2 < (x.Count > yList.Count ? yList.Count : x.Count);
                    i2++, posPoint++)
                {
                    Points[i1].Add(new DataPoint(x[posPoint],
                              double.Parse(yList[i2], System.Globalization.CultureInfo.InvariantCulture)));
                    chart.Series[nameLines[i1]].Points.Add(Points[i1][i2]);
                    chart.Update();
                }
                chart.Series[nameLines[i1]].ToolTip = "X = #VALX, Y = #VALY";
            }
        }

        public static void AddPoints(
            this Chart chart, MouseEventArgs e)
        {
            HitTestResult res = chart.HitTest(e.X, e.Y);
            if (res.Series != null)
            {

                for (int i1 = 0; i1 < Config.nameLines.Count; i1++)
                {
                    for (int i = 0; i < Points[i1].Count; i++)
                    {
                        if (Points[i1][i].XValue == res.Series.Points[res.PointIndex].XValue &&
                            Points[i1][i].YValues[0] == res.Series.Points[res.PointIndex].YValues[0])
                        {
                            chart.Series[Config.nameLines[i1]].Points[i].Label = "x=" + Points[i1][i].XValue + " y=" + Points[i1][i].YValues[0];
                            chart.Series[Config.nameLines[i1]].Points[i].LabelBackColor = chart.BackColor;

                            chart.Series[Config.nameLines[i1]].Points[i].MarkerColor = Color.Red;
                            chart.Series[Config.nameLines[i1]].Points[i].MarkerStyle = MarkerStyle.Circle;
                            chart.Series[Config.nameLines[i1]].Points[i].MarkerSize = 6;
                            chart.Update();
                        }
                    }
                }
            }
        }

        #endregion

        #region Checking X Y

        public static List<double> CheckingXinput(string xInputText)
        {
            List<double> xList = CheckingInputText(xInputText);
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
            List<double> chekingList = CheckingInputText(yInputText);
            if (chekingList.Count != 0)
                yList.Add(string.Join(" ", chekingList));
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

        private static List<double> CheckingInputText(string inputText)
        {
            List<double> inputList = new List<double>();

            if (inputText.Contains(":"))
                inputList = Parser(inputText);

            else if (inputText.Contains("random"))
                inputList = Random(inputText, random);

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

        #endregion

    }
}
