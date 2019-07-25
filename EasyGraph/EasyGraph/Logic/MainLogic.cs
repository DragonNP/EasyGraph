using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static EasyGraph.CheckingXY;
using static EasyGraph.Utilities;

namespace EasyGraph.Logic
{
    public class MainLogic
    {
        public static bool IsContinue = true;
        public static List<Points> points = new List<Points>();
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
                $"y = [{string.Join("][", y).Replace(",", " ")}]";
        }

        public static void TabControl_Update(Form1 form1)
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

                if (points.Count != 0)
                {
                    form1.PointSel.Items.Clear();
                    foreach (Points point in points)
                    {
                        if (!point.Visible) continue;
                        form1.PointSel.Items.Add(point.Point.Label);
                    }
                    if (form1.PointSel.Items.Count != 0)
                    {
                        form1.PointSel.SelectedIndex = 0;
                        PointSel_DropDownClosed(form1);
                    }
                }
            }
            else if (form1.TabControl.SelectedIndex == 2)
                Show_Values(form1);
        }

        public static void LineSel_DropDownClosed(Form1 form1)
        {
            if (Config.nameLines.Count == 0) return;

            form1.NameLineBox.Text = form1.LineSel.SelectedItem.ToString();
            form1.ColorLineBox.Text = ColorToString(Config.LineColor[form1.LineSel.SelectedIndex]);
            form1.LineSel.Update();
        }

        public static void PointSel_DropDownClosed(Form1 form1)
        {
            if (form1.PointSel.SelectedIndex == -1) return;

            foreach (Points point in points)
            {
                if (!point.Visible || point.Point.Label != form1.PointSel.SelectedItem.ToString()) continue;

                form1.NamePointBox.Text = point.Point.Label;
                form1.ColorPointBox.Text = ColorToString(point.Point.MarkerColor);
                form1.PointSel.Update();
            }
        }

        public static void Set_Line(Form1 form1)
        {
            form1.chart.Series[form1.LineSel.SelectedIndex].Name = form1.NameLineBox.Text;
            Config.nameLines[form1.LineSel.SelectedIndex] = form1.NameLineBox.Text;

            form1.chart.Series[form1.LineSel.SelectedIndex].Color = StringToColor(form1.ColorLineBox.Text);
            Config.LineColor[form1.LineSel.SelectedIndex] = form1.chart.Series[form1.LineSel.SelectedIndex].Color;
            form1.TabControl.SelectedIndex = 0;
        }

        public static void Set_Point(Form1 form1)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].Visible || points[i].Point.Label != form1.PointSel.SelectedItem.ToString()) continue;
                points[i].Point.Label = form1.NamePointBox.Text;
                form1.chart.Series[points[i].IndexLine].Points[points[i].Index] = points[i].Point;
                break;
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].Visible || points[i].Point.Label != form1.PointSel.SelectedItem.ToString()) continue;
                points[i].Point.MarkerColor = StringToColor(form1.ColorPointBox.Text);
                form1.chart.Series[points[i].IndexLine].Points[points[i].Index] = points[i].Point;
                form1.TabControl.SelectedIndex = 0;
                break;
            }
        }
    }
}
