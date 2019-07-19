using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static EasyGraph.Logic;
using static EasyGraph.Languages;
using static EasyGraph.Utilities;
using System.Threading.Tasks;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        private readonly List<double> x = new List<double>();
        private readonly List<string> y = new List<string>();

        public Form1()
        {
            InitializeComponent();

            SetLanguage();
            SetNames();
            chart.Initialize(title: Config.LanguageLocale[5], legendsTitle: Config.LanguageLocale[6], font: Config.font);

            Save.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";

            #region Events

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
            };

            LanguageEnglish.Click += (s, e) =>
            {
                Languages.SetLanguage("English");
            };

            chart.MouseClick += (s, e) => chart.AddPoints(e);

            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            LineSel.DropDownClosed += LineSel_DropDownClosed;
            Build.Click += Build_Click;
            #endregion

            #region KeyDown
            NameLineBox.KeyDown += (s, a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    chart.Series[LineSel.SelectedIndex].Name = NameLineBox.Text;
                    Config.nameLines[LineSel.SelectedIndex] = NameLineBox.Text;
                    int i = LineSel.SelectedIndex;
                    TabControl_SelectedIndexChanged(TabControl, null);
                    LineSel_DropDownClosed(LineSel, null);
                    LineSel.SelectedIndex = i;
                }
            };

            ColorLineBox.KeyDown += (s, a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    chart.Series[LineSel.SelectedIndex].Color = Utilities.StringToColor(ColorLineBox.Text);
                    Config.LineColor[LineSel.SelectedIndex] = chart.Series[LineSel.SelectedIndex].Color;
                    int i = LineSel.SelectedIndex;
                    TabControl_SelectedIndexChanged(TabControl, null);
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
            PageChart.Text = Config.LanguageLocale[10];
            PageEdit.Text = Config.LanguageLocale[11];
            PageOuput.Text = Config.LanguageLocale[12];
            NameLine.Text = Config.LanguageLocale[13];
            ColorLine.Text = Config.LanguageLocale[14];
            NamePoint.Text = Config.LanguageLocale[15];
            ColorPoint.Text = Config.LanguageLocale[16];

            NameLineBox.Location = new Point(NameLine.Location.X + NameLine.Width + 3,
                NameLine.Location.Y);
            ColorLineBox.Location = new Point(ColorLine.Location.X + ColorLine.Width + 3,
                ColorLine.Location.Y);

            NamePointBox.Location = new Point(NamePoint.Location.X + NamePoint.Width + 3,
                NamePoint.Location.Y);
            ColorPointBox.Location = new Point(ColorPoint.Location.X + ColorPoint.Width + 3,
                ColorPoint.Location.Y);

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

        #region Events Methods
        void Build_Click(object sender, EventArgs e)
        {
            List<double> x;
            List<string> y;
            Config.nameLines.Clear();
            TabControl.SelectedTab = PageChart;

            x = CheckingXinput(xInputText: xInput.Text);
            y = CheckingYinput(yInputText: yInput.Text);

            if (Utilities.isContinue)
                chart.PlotLine(x, y, nameLines: Config.nameLines);
        }

        void LineSel_DropDownClosed(object sender, EventArgs e)
        {
            if (Config.nameLines.Count == 0) return;

            NameLineBox.Text = LineSel.SelectedItem.ToString();
            ColorLineBox.Text = ColorArrayToStringArray()[LineSel.SelectedIndex];
            LineSel.Update();
        }

        async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (TabControl.SelectedIndex == 1 && Config.nameLines.Count != 0 && Points.Count != 0)
                {
                    PointSel.Items.Clear();
                    foreach (List<DataPoint> pointsList in Points)
                        PointSel.Items.AddRange(pointsList.ToArray());

                    LineSel.Items.Clear();
                    LineSel.Items.AddRange(Config.nameLines.ToArray());
                    LineSel.SelectedIndex = 0;
                    LineSel_DropDownClosed(LineSel, e);
                }
            });
        }
        #endregion
    }
}
