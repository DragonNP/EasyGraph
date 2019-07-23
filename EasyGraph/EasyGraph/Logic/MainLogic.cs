using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static EasyGraph.CheckingXY;
using static EasyGraph.Utilities;

namespace EasyGraph.Logic
{
    public static class MainLogic
    {
        public static bool IsContinue { get; set; } = true;
        public static List<List<DataPoint>> PointsAll = new List<List<DataPoint>>();
        public static List<List<string>> PointsName = new List<List<string>>();
        private static List<double> x = new List<double>();
        private static List<string> y = new List<string>();

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

        public static void LineSel_DropDownClosed(Form1 form1)
        {
            if (Config.nameLines.Count == 0) return;

            form1.NameLineBox.Text = form1.LineSel.SelectedItem.ToString();
            form1.ColorLineBox.Text = ColorToString(Config.LineColor[form1.LineSel.SelectedIndex]);
            form1.LineSel.Update();
        }

        public static void TabControl_SelectedIndexChanged(Form1 form1)
        {
            if (form1.TabControl.SelectedIndex == 1)
            {
                if (Config.nameLines.Count != 0)
                {
                    form1.LineSel.Items.Clear();
                    form1.LineSel.Items.AddRange(Config.nameLines.ToArray());
                    form1.LineSel.SelectedIndex = 0;
                    LineSel_DropDownClosed(form1);
                }

                if (PointsName.Count != 0)
                {
                    form1.PointSel.Items.Clear();
                    foreach (List<string> pointsList in PointsName)
                        form1.PointSel.Items.AddRange(pointsList.ToArray());
                    form1.PointSel.SelectedIndex = 0;
                    PointSel_DropDownClosed(form1);
                }
            }
            else if (form1.TabControl.SelectedIndex == 2)
                Show_Values(form1);
        }

        public static void PointSel_DropDownClosed(Form1 form1)
        {
            if (PointsName.Count == 0) return;

            form1.NamePointBox.Text = form1.PointSel.SelectedItem.ToString();
            //chart.Series[Config.nameLines[i1]].Points[i].MarkerColor;
            //ColorPointBox.Text = ColorToString(chart.Series[Config.nameLines[]].Points[].MarkerColor);
            form1.PointSel.Update();
        }
    }
}
