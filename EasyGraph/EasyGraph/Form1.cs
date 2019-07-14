﻿using EasyGraph.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        private bool isContinue = true;
        private List<double> x = new List<double>();
        private List<double> y = new List<double>();
        private readonly Random random = new Random();


        public Form1()
        {
            InitializeComponent();
            ParsingLanguage(ReadLanguage());
            SetNames();


            // Инециализируем график
            chart.Initialize(title: Config.Graph, legendsTitle: Config.Legend, font: Config.font);


            // Если пользователь нажал на кпопку доната
            Donation.Click += (s, e) => 
                System.Diagnostics.Process.Start("https://money.yandex.ru/to/410016387696692");

            LanguageRussian.Click += (s, e) =>
            {
                LanguageRussian.Checked = true;
                LanguageEnglish.Checked = false;
                SetLanguage("Russian");
                Application.Restart();
                Environment.Exit(0);
            };

            LanguageEnglish.Click += (s, e) =>
            {
                LanguageRussian.Checked = false;
                LanguageEnglish.Checked = true;
                SetLanguage("English");
                Application.Restart();
                Environment.Exit(0);
            };
        }

        private void ShowValue_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = $"x = {string.Join(" ", x)}\n" +
                                $"y = {string.Join(" ", y)}";
        }

        void SetNames()
        {
            showValues.Text = Config.Show_values;
            Options.Text = Config.Options;
            Donation.Text = Config.Donation;
            Language.Text = Config.LanguageMenuStrip;
            Done.Text = Config.Build;

        }

        private void ParsingLanguage(string lang)
        {
            ResourceManager RM = new ResourceManager("EasyGraph.Properties.Resources", typeof(Resources).Assembly);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(RM.GetObject("languages").ToString());
            XmlElement xRoot = xDoc.DocumentElement;


            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.GetNamedItem("lang").Value != lang)
                    continue;
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "show_values":
                            Config.Show_values = childnode.InnerText;
                            break;

                        case "options":
                            Config.Options = childnode.InnerText;
                            break;

                        case "languageMenuStrip":
                            Config.LanguageMenuStrip = childnode.InnerText;
                            break;

                        case "donation":
                            Config.Donation = childnode.InnerText;
                            break;

                        case "build":
                            Config.Build = childnode.InnerText;
                            break;

                        case "graph":
                            Config.Graph = childnode.InnerText;
                            break;

                        case "legend":
                            Config.Legend = childnode.InnerText;
                            break;

                        case "line":
                            Config.Line = childnode.InnerText;
                            break;
                    }
                }
            }
        }

        private void SetLanguage(string language)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Config.PathRegistry))
            {
                switch (language)
                {
                    case "Russian":
                        key.SetValue("Language", "Russian");
                        ParsingLanguage("Russian");
                        break;

                    case "English":
                        key.SetValue("Language", "English");
                        ParsingLanguage("English");
                        break;
                }
            }
        }

        string ReadLanguage()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Config.PathRegistry))
            {
                string language;
                if (key.GetValue("Language", null) != null)
                    language = key.GetValue("Language").ToString();
                else
                {
                    key.SetValue("Language", "English");
                    language = key.GetValue("Language").ToString();
                }
                return language;
            }
        }

        private List<double> Random(string text)
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

        private List<double> Parser(string text)
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
                MessageBox.Show(caption: "Ошибка",
                    text: "Неверно задан пареметр!\nФормат нач.значение:шаг:кон.значение или нач.значение:кон.значение",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
                isContinue = false;
                return null;
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            x.Clear();
            y.Clear();

            Invoke((MethodInvoker)(() =>
            {
                isContinue = true;
                if (richTextBox1.Text.Contains(":"))
                    x = Parser(richTextBox1.Text);
                else if (richTextBox1.Text == "y")
                    x = y;
                else if (richTextBox1.Text.Contains("random"))
                    x = Random(richTextBox1.Text);
                else
                {
                    foreach (string i in richTextBox1.Text.Split(new char[] { '\n', ' ' }))
                        x.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));
                }
            }));

            Invoke((MethodInvoker)(() =>
            {
                isContinue = true;
                if (richTextBox2.Text.Contains(":"))
                    y = Parser(richTextBox2.Text);
                else if (richTextBox2.Text == "x")
                    y = x;
                else if (richTextBox2.Text.Contains("random"))
                    y = Random(richTextBox2.Text);
                else
                {
                    foreach (string i in richTextBox2.Text.Split(new char[] { '\n', ' ' }))
                        y.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));
                }
            }));

            if (isContinue)
                ToDisplayGraph(x, y);
        }

        private void ToDisplayGraph(List<double> x, List<double> y)
        {
            double minX = -1, maxX = -1;
            double minY = -1, maxY = -1;

            Invoke((MethodInvoker)(() =>
            {
                bool first = true;
                for (int i = 0; i < (x.Count >= y.Count ? y.Count : x.Count); i++)
                {
                    if (first)
                    {
                        first = false;
                        minY = y[i];
                        maxY = y[i];

                        minX = x[i];
                        maxX = x[i];
                    }

                    if (minY > y[i]) minY = y[i];
                    else if (maxY < y[i]) maxY = y[i];

                    if (minX > x[i]) minX = x[i];
                    else if (maxX < x[i]) maxX = x[i];
                }

                chart.AxisXY_Min_Max("area", minX, maxX, minY, maxY, isClear:true);
                chart.AddSeries(nameLine: Config.Line, borderWidth: 3, font: Config.font);

                for (int i = 0; i < (x.Count >= y.Count ? y.Count : x.Count); i++)
                {
                    chart.Series[Config.Line].Points.AddXY(x[i], y[i]);
                    chart.Update();
                }
                chart.Series[Config.Line].ToolTip = "X = #VALX, Y = #VALY";
            }));
        }

    }
    public static class Graph
    {
        //private static Font font = new Font("Arial", 12, FontStyle.Regular);

        #region Method public Initialize
        public static void Initialize(this Chart chart,
                                      string title,
                                      string legendsTitle,
                                      Font font,
                                      string axisXTitle = "X",
                                      string axisYTitle = "Y",
                                      string areasName = "area",
                                      Color color = default,
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
        #endregion

        #region Method public AddSeries
        public static void AddSeries(this Chart chart,
                                      Font font = default,
                                      string nameLine = "Line1",
                                      ChartDashStyle chartDashStyle = ChartDashStyle.Solid,
                                      int borderWidth = 5,
                                      Color color = default,
                                      SeriesChartType chartType = SeriesChartType.Line)
        {
            if (color.IsEmpty) color = Color.DarkBlue;

            chart.Series.Add(nameLine);
            chart.Series[nameLine].BorderDashStyle = chartDashStyle;
            chart.Series[nameLine].BorderWidth = borderWidth;
            chart.Series[nameLine].Color = color;
            chart.Series[nameLine].Font = font;
            chart.Series[nameLine].ChartType = chartType;
            chart.Update();
        }
        #endregion

        #region Method AxisXY_Min_Max
        public static void AxisXY_Min_Max(this Chart chart, string areasName, double minX, double maxX,
                                          double minY, double maxY, bool isClear = false)
        {
            if (isClear) chart.Series.Clear();
            chart.ChartAreas[areasName].AxisX.Minimum = minX;
            chart.ChartAreas[areasName].AxisX.Maximum = maxX;

            chart.ChartAreas[areasName].AxisY.Minimum = minY;
            chart.ChartAreas[areasName].AxisY.Maximum = maxY;
        }
        #endregion
    }
}
