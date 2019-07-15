using EasyGraph.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        private List<double> x = new List<double>();
        private List<double> y = new List<double>();
        private readonly List<DataPoint> point = new List<DataPoint>();

        public Form1()
        {
            InitializeComponent();
            Languages.ParsingLanguage();
            SetNames();
            chart.Initialize(title: Config.Graph, legendsTitle: Config.Legend, font: Config.font);

            Save.Filter = "PNG Image(*.png)|*.png|" +
                "JPEG Image(*.jpeg)|*.jpeg|" +
                "BMP Image(*.bmp)|*.bmp|";

            SaveAs.Click += (s, e) =>
            {
                Save.FileName = "Chart";
                if (Save.ShowDialog() == DialogResult.Cancel)
                    return;

                string filename = Save.FileName;
                switch (Save.FilterIndex)
                {
                    case 1: chart.SaveImage(filename, System.Drawing.Imaging.ImageFormat.Png);  break;
                    case 2: chart.SaveImage(filename, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 3: chart.SaveImage(filename, System.Drawing.Imaging.ImageFormat.Png); break;
                }
            };

            Donation.Click += (s, e) => 
                System.Diagnostics.Process.Start("https://money.yandex.ru/to/410016387696692");

            showValues.Click += (s, e) =>
            {
                richTextBox3.Text = $"x = {string.Join(" ", x)}\n" +
                    $"y = {string.Join(" ", y)}";
            };

            LanguageRussian.Click += (s, e) =>
            {
                Languages.SetLanguage(LanguageRussian: ref LanguageRussian,
                      LanguageEnglish: ref LanguageEnglish,
                      "Russian");
                Application.Restart();
                Environment.Exit(0);
            };

            LanguageEnglish.Click += (s, e) =>
            {
                Languages.SetLanguage(LanguageRussian: ref LanguageRussian,
                      LanguageEnglish: ref LanguageEnglish,
                      "English");
                Application.Restart();
                Environment.Exit(0);
            };

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && richTextBox1.Focused)
                    richTextBox2.Focus();
                else if (e.KeyCode == Keys.Enter && richTextBox2.Focused)
                    Build_Click(Build, null);                    
            };
        }

        void SetNames()
        {
            showValues.Text = Config.Show_values;
            Options.Text = Config.Options;
            Donation.Text = Config.Donation;
            Language.Text = Config.LanguageMenuStrip;
            Build.Text = Config.Build;
            if (Config.Show_values == "Show values")
            {
                LanguageRussian.Checked = false;
                LanguageEnglish.Checked = true;
            }
            else
            {
                LanguageRussian.Checked = true;
                LanguageEnglish.Checked = false;
            }
        }

        private void Build_Click(object sender, EventArgs e)
        {
            x.Clear();
            y.Clear();

            Invoke((MethodInvoker)(() =>
            {
                Utilities.isContinue = true;
                if (richTextBox1.Text.Contains(":"))
                    x = Utilities.Parser(richTextBox1.Text);
                else if (richTextBox1.Text == "y")
                    x = y;
                else if (richTextBox1.Text.Contains("random"))
                    x = Utilities.Random(richTextBox1.Text);
                else
                {
                    foreach (string i in richTextBox1.Text.Split(new char[] { '\n', ' ' }))
                        x.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));
                }

                if (richTextBox2.Text.Contains(":"))
                    y = Utilities.Parser(richTextBox2.Text);
                else if (richTextBox2.Text == "x")
                    y = x;
                else if (richTextBox2.Text.Contains("random"))
                    y = Utilities.Random(richTextBox2.Text);
                else
                {
                    foreach (string i in richTextBox2.Text.Split(new char[] { '\n', ' ' }))
                        y.Add(double.Parse(i, System.Globalization.CultureInfo.InvariantCulture));
                }
            }));

            if (Utilities.isContinue)
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
                point.Clear();
                chart.AddSeries(nameLine: Config.Line, borderWidth: 3, font: Config.font);

                for (int i = 0; i < (x.Count >= y.Count ? y.Count : x.Count); i++)
                {
                    point.Add(new DataPoint(x[i], y[i]));
                    chart.Series[Config.Line].Points.Add(point[i]);
                    chart.Update();
                }
                
                chart.Series[Config.Line].ToolTip = "X = #VALX, Y = #VALY";
            }));
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            var res = chart.HitTest(e.X, e.Y);
            if (res.Series != null)
            {
                for(int i = 0; i < point.Count; i++)
                {
                    if(point[i].XValue == res.Series.Points[res.PointIndex].XValue &&
                        point[i].YValues[0] == res.Series.Points[res.PointIndex].YValues[0])
                    {
                        chart.Series[Config.Line].Points[i].Label = "x=" + point[i].XValue + " y=" + point[i].YValues[0];
                        chart.Series[Config.Line].Points[i].LabelBackColor = chart.BackColor;

                        chart.Series[Config.Line].Points[i].MarkerColor = Color.Red;
                        chart.Series[Config.Line].Points[i].MarkerStyle = MarkerStyle.Circle;
                        chart.Series[Config.Line].Points[i].MarkerSize = 6;
                        chart.Update();
                    }
                }
            }

        }
    }
    public static class Graph
    {

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
