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
        private bool isContinue = true;
        private List<double> x = new List<double>();
        private List<double> y = new List<double>();
        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart.Initialize(title: "График", legendsTitle: "Легенда");
        }

        private void ShowValue_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = $"x = {string.Join("; ", x)}\n" +
                $"y = { string.Join("; ", y)}";
        }

        private List<double> Random(string text)
        {

            double min, max, col;
            text = text.Replace("random", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace(" ", "");
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

                //chart.Series.Clear();
                chart.ChartAreas["area"].AxisX.Minimum = minX;
                chart.ChartAreas["area"].AxisX.Maximum = maxX;

                chart.ChartAreas["area"].AxisY.Minimum = minY;
                chart.ChartAreas["area"].AxisY.Maximum = maxY;

                chart.Series.Add(name.Text);
                chart.Series[name.Text].BorderDashStyle = ChartDashStyle.Solid;
                chart.Series[name.Text].BorderWidth = 5;
                chart.Series[name.Text].Color = Color.DarkBlue;
                chart.Series[name.Text].Font = new Font("Segoe UI Semilight", 18, FontStyle.Regular);
                chart.Series[name.Text].ChartType = SeriesChartType.Line;
                chart.Update();

                for (int i = 0; i < (x.Count >= y.Count ? y.Count : x.Count); i++)
                {
                    chart.Series[name.Text].Points.AddXY(x[i], y[i]);
                    chart.Update();
                }
            }));
        }
    }
    public static class Graph
    {
        public static void Initialize(this Chart chart,
                                      string title = "График by DragonNP",
                                      string areasName = "area",
                                      string legendsTitle = "Legends",
                                      string axisXTitle = "X",
                                      string axisYTitle = "Y",
                                      AxisArrowStyle axisArrowStyle = AxisArrowStyle.Triangle,
                                      Font font = null)
        {
            if (font == null) font = new Font("Segoe UI Semilight", 18, FontStyle.Regular);

            chart.Titles.Add(title).Font = font;
            chart.Legends.Add(title);
            chart.Legends[title].Title = legendsTitle;

            chart.ChartAreas.Add(areasName);
            chart.ChartAreas[areasName].AxisX.Title = axisXTitle;
            chart.ChartAreas[areasName].AxisX.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisX.TitleFont = font;
            chart.ChartAreas[areasName].AxisX.TitleForeColor = Color.Black;

            chart.ChartAreas[areasName].AxisY.Title = axisYTitle;
            chart.ChartAreas[areasName].AxisY.ArrowStyle = axisArrowStyle;
            chart.ChartAreas[areasName].AxisY.TitleFont = font;
            chart.ChartAreas[areasName].AxisY.TitleForeColor = Color.Black;
        }
    }
}
