using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        private List<double> x = new List<double>();
        private List<string> y = new List<string>();
        private readonly List<List<DataPoint>> points = new List<List<DataPoint>>();

        public Form1()
        {
            InitializeComponent();

            Languages.ParsingLanguage();
            SetNames();
            chart.Initialize(title: Config.LanguageLocale[5], legendsTitle: Config.LanguageLocale[6], font: Config.font);

            #region File Save
            Save.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";

            SaveAs.Click += (s, e) =>
            {
                Save.FileName = "Chart";
                if (Save.ShowDialog() == DialogResult.Cancel)
                    return;

                switch (Save.FilterIndex)
                {
                    case 1: chart.SaveImage(Save.FileName, ChartImageFormat.Bmp); break;
                    case 2: chart.SaveImage(Save.FileName, ChartImageFormat.Png); break;
                    case 3: chart.SaveImage(Save.FileName, ChartImageFormat.Jpeg); break;
                }
            };
            #endregion

            #region Click
            Donation.Click += (s, e) =>
                System.Diagnostics.Process.Start("https://money.yandex.ru/to/410016387696692");

            showValues.Click += (s, e) =>
            {
                TabControl.SelectedTab = PageOuput;
                output.Text = $"x = {string.Join(" ", x)}\n" +
                    $"y = {string.Join(" ", y)}";
            };

            LanguageRussian.Click += (s, e) =>
            {
                Languages.SetLanguage("Russian");
                Application.Restart();
                Environment.Exit(0);
            };

            LanguageEnglish.Click += (s, e) =>
            {
                Languages.SetLanguage("English");
                Application.Restart();
                Environment.Exit(0);
            };
            #endregion

            #region KeyDown
            NameBox.KeyDown += (s, a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    chart.Series[LineSel.SelectedIndex].Name = NameBox.Text;
                    Config.nameLines[LineSel.SelectedIndex] = NameBox.Text;
                    int i = LineSel.SelectedIndex;
                    LineSel_DropDownClosed(LineSel, null);
                    LineSel.SelectedIndex = i;
                }
            };

            ColorBox.KeyDown += (s, a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    chart.Series[LineSel.SelectedIndex].Color = StringToColor(ColorBox.Text);
                    int i = LineSel.SelectedIndex;
                    LineSel_DropDownClosed(LineSel, null);
                    LineSel.SelectedIndex = i;
                }
            };

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && xInput.Focused)
                    yInput.Focus();
                else if (e.KeyCode == Keys.Enter && yInput.Focused)
                    Build_Click(Build, null);
            };
            #endregion
        }

        void SetNames()
        {
            showValues.Text = Config.LanguageLocale[0];
            Options.Text = Config.LanguageLocale[1];
            Language.Text = Config.LanguageLocale[2];
            Donation.Text = Config.LanguageLocale[3];
            Build.Text = Config.LanguageLocale[4];
            File.Text = Config.LanguageLocale[8];
            SaveAs.Text = Config.LanguageLocale[9];
            if (Config.LanguageLocale[0] == "Show values")
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

        void Build_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = PageChart;

            x = Utilities.CheckingXinput(xInputText: xInput.Text);
            y = Utilities.CheckingYinput(yInputText: yInput.Text);

            if (Utilities.isContinue)
                PlotLine(x, y, nameLines: Config.nameLines);
        }

        void PlotLine(List<double> x, List<string> y, List<string> nameLines)
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

            points.Clear();
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
                points.Add(new List<DataPoint>());

                for (int i2 = 0;
                    i2 < (x.Count > yList.Count ? yList.Count : x.Count);
                    i2++, posPoint++)
                {
                    points[i1].Add(new DataPoint(x[posPoint],
                              double.Parse(yList[i2], System.Globalization.CultureInfo.InvariantCulture)));
                    chart.Series[nameLines[i1]].Points.Add(points[i1][i2]);
                    chart.Update();
                }
                chart.Series[nameLines[i1]].ToolTip = "X = #VALX, Y = #VALY";
            }
        }

        void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult res = chart.HitTest(e.X, e.Y);
            if (res.Series != null)
            {

                for (int i1 = 0; i1 < Config.nameLines.Count; i1++)
                {
                    for (int i = 0; i < points[i1].Count; i++)
                    {
                        if (points[i1][i].XValue == res.Series.Points[res.PointIndex].XValue &&
                            points[i1][i].YValues[0] == res.Series.Points[res.PointIndex].YValues[0])
                        {
                            chart.Series[Config.nameLines[i1]].Points[i].Label = "x=" + points[i1][i].XValue + " y=" + points[i1][i].YValues[0];
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
        void LineSel_DropDownClosed(object sender, EventArgs e)
        {
            NameBox.Text = LineSel.SelectedItem.ToString();
            NameBox.Location = new Point(NameLabel.Location.X + NameLabel.Width + 3,
                    NameLabel.Location.Y);
            ColorBox.Text = ColorArrayToStringArray()[LineSel.SelectedIndex];
        }

        void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 1)
            {
                LineSel.Items.Clear();
                LineSel.Items.AddRange(Config.nameLines.ToArray());
                LineSel.SelectedIndex = 0;
                LineSel_DropDownClosed(sender, e);
            }
        }

        string[] ColorArrayToStringArray()
        {
            List<string> stringColor = new List<string>();
            foreach (Color color in Config.LineColor)
                stringColor.Add($"{color.R}, {color.G}, {color.B}");

            return stringColor.ToArray();
        }

        Color StringToColor(string str)
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
                                      List<string> nameLines,
                                      List<Color> colors,
                                      int borderWidth = 5,
                                      bool isClear = false,
                                      Font font = default,
                                      ChartDashStyle chartDashStyle = ChartDashStyle.Solid,
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
        #endregion

        #region Method AxisXY_Min_Max
        public static void AxisXY_Min_Max(this Chart chart, string areasName,
                                          double minX, double maxX,
                                          double minY, double maxY)
        {
            
            chart.ChartAreas[areasName].AxisX.Minimum = minX;
            chart.ChartAreas[areasName].AxisX.Maximum = maxX;

            chart.ChartAreas[areasName].AxisY.Minimum = minY;
            chart.ChartAreas[areasName].AxisY.Maximum = maxY;
        }
        #endregion
    }
}
