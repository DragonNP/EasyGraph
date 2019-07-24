using EasyGraph.Logic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EasyGraph.Languages;
using static EasyGraph.Logic.MainLogic;
using static EasyGraph.Utilities;

namespace EasyGraph
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Config.LanguageLocale = GetLanguage(this, PathRegistry: Config.PathRegistry);
            chart.Initialize(title: Config.LanguageLocale[5], legendsTitle: Config.LanguageLocale[6], font: Config.font);

            #region Events
            SaveAs.Click += async (s, e) => await Task.Run(() => Save_Chart(this));

            Build.Click += async (s, e) => await Task.Run(() => Build_Chart(this));

            chart.MouseClick += async (s, e) => await Task.Run(() => chart.AddPoints(e));

            LanguageRussian.Click += async (s, e) => await Task.Run(() => SetLanguage("Russian", Config.PathRegistry));

            LanguageEnglish.Click += async (s, e) => await Task.Run(() => SetLanguage("English", Config.PathRegistry));

            Donation.Click += async (s, e) => await Task.Run(() =>
                System.Diagnostics.Process.Start("https://money.yandex.ru/to/410016387696692"));

            TabControl.SelectedIndexChanged += async (s, e) => await Task.Run(() => TabControl_Update(this));

            LineSel.DropDownClosed += async (s, e) => await Task.Run(() => LineSel_DropDownClosed(this));

            PointSel.DropDownClosed += async (s, e) => await Task.Run(() => PointSel_DropDownClosed(this));
            #endregion

            #region KeyDown
            NameLineBox.KeyDown += async (s, a) => await Task.Run(() =>
            {
                if (a.KeyCode != Keys.Enter) return;

                chart.Series[LineSel.SelectedIndex].Name = NameLineBox.Text;
                Config.nameLines[LineSel.SelectedIndex] = NameLineBox.Text;
                TabControl_Update(this);
                TabControl.SelectedIndex = 0;

            });

            ColorLineBox.KeyDown += async (s, a) => await Task.Run(() =>
            {
                if (a.KeyCode != Keys.Enter) return;

                chart.Series[LineSel.SelectedIndex].Color = StringToColor(ColorLineBox.Text);
                Config.LineColor[LineSel.SelectedIndex] = chart.Series[LineSel.SelectedIndex].Color;
                TabControl_Update(this);
                TabControl.SelectedIndex = 0;

            });

            NamePointBox.KeyDown += async (s, a) => await Task.Run(() =>
            {
                if (a.KeyCode != Keys.Enter) return;
                for(int i = 0; i < points.Count; i++)
                {
                    if (!points[i].Visible || points[i].Point.Label != PointSel.SelectedItem.ToString()) continue;

                    points[i].Point.Label = NamePointBox.Text;
                    chart.Series[points[i].IndexLine].Points[points[i].Index] = points[i].Point;
                    TabControl_Update(this);
                    TabControl.SelectedIndex = 0;
                    break;
                }


            });

            ColorPointBox.KeyDown += async (s, a) => await Task.Run(() =>
            {
                if (a.KeyCode != Keys.Enter) return;

                for (int i = 0; i < points.Count; i++)
                {
                    if (!points[i].Visible || points[i].Point.Label != PointSel.SelectedItem.ToString()) continue;

                    points[i].Point.MarkerColor = StringToColor(ColorPointBox.Text);
                    chart.Series[points[i].IndexLine].Points[points[i].Index] = points[i].Point;
                    TabControl_Update(this);
                    TabControl.SelectedIndex = 0;
                    break;
                }
            });

            KeyDown += async (s, e) => await Task.Run(() =>
            {
                if (e.KeyCode == Keys.Enter && xInput.Focused)
                    yInput.Focus();
                else if (e.KeyCode == Keys.Enter && yInput.Focused)
                    Build_Chart(this);
            });
            #endregion
        }
    }
}
