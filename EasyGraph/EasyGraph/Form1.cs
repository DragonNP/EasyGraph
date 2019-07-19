using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static EasyGraph.Languages;
using static EasyGraph.Logic;
using static EasyGraph.Utilities;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        private readonly List<double> x = new List<double>();
        private readonly List<string> y = new List<string>();

        public Form1()
        {
            InitializeComponent();

            Config.LanguageLocale = GetLanguage(this, PathRegistry: Config.PathRegistry);
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

            LanguageRussian.Click += (s, e) => SetLanguage("Russian", Config.PathRegistry);

            LanguageEnglish.Click += (s, e) => SetLanguage("English", Config.PathRegistry);

            chart.MouseClick += (s, e) => chart.AddPoints(e);

            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            LineSel.DropDownClosed += LineSel_DropDownClosed;

            Build.Click += (s, e) => Build_Chart(form1: this);
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
                    Build_Chart(form1: this);
            };
            #endregion
        }

        #region Events Methods

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
