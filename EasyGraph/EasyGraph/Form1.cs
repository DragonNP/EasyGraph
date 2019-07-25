using EasyGraph.Logic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EasyGraph.Languages;
using static EasyGraph.Logic.MainLogic;

namespace EasyGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Config.LanguageLocale = GetLanguage(this, PathRegistry: Config.PathRegistry);
            chart.Initialize(title: Config.LanguageLocale[4], legendsTitle: Config.LanguageLocale[5], font: Config.font);

            #region Events
            SaveAs.Click += (s, e) => BeginInvoke((MethodInvoker)(async () => 
            {
                await Task.Run(() => Save_Chart(this));
            }));

            Build.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => Build_Chart(this));
            }));

            chart.MouseClick += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => chart.AddPoints(e));
            }));

            LanguageRussian.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => SetLanguage("Russian", Config.PathRegistry));
            }));

            LanguageEnglish.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => SetLanguage("English", Config.PathRegistry));
            }));

            Donation.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => Process.Start("https://money.yandex.ru/to/410016387696692"));
            }));

            TabControl.SelectedIndexChanged += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => TabControl_Update(this));
            }));

            LineSel.DropDownClosed += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => LineSel_DropDownClosed(this));
            }));

            PointSel.DropDownClosed += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => PointSel_DropDownClosed(this));
            }));

            DoneLine.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => Set_Line(this));
            }));

            DonePoint.Click += (s, e) => BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Run(() => Set_Point(this));
            }));
            #endregion

            #region KeyDown
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
