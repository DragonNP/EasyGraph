using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static EasyGraph.Logic.MainLogic;

namespace EasyGraph.Logic
{
    public static class ChartExtensions
    {
        public static void Initialize(
            this Chart chart, string title, string legendsTitle, Font font, string axisXTitle = "X",
            string axisYTitle = "Y", string areasName = "area", Color color = default,
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

        private static void AddSeries(
            this Chart chart, List<string> nameLines, List<Color> colors, int borderWidth = 5, bool isClear = false,
            Font font = default, ChartDashStyle chartDashStyle = ChartDashStyle.Solid,
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

        private static void AxisXY_Min_Max(this Chart chart, string areasName,
            double minX, double maxX, double minY, double maxY)
        {

            chart.ChartAreas[areasName].AxisX.Minimum = minX;
            chart.ChartAreas[areasName].AxisX.Maximum = maxX;

            chart.ChartAreas[areasName].AxisY.Minimum = minY;
            chart.ChartAreas[areasName].AxisY.Maximum = maxY;
        }

        public static void PlotLine(
            this Chart chart, List<double> x, List<string> y, List<string> nameLines)
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
            chart.AxisXY_Min_Max(
                areasName: "area",
                minX: minX,
                maxX: maxX,
                minY: minY,
                maxY: maxY);
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

                int index = 0;
                for (int i2 = 0;
                    i2 < (x.Count > yList.Count ? yList.Count : x.Count);
                    i2++, posPoint++)
                {
                    points.Add(new Points(i1, new DataPoint(x[posPoint],
                              double.Parse(yList[i2], System.Globalization.CultureInfo.InvariantCulture)), index));
                    chart.Series[nameLines[i1]].Points.Add(points[posPoint].Point);
                    chart.Update();
                    index++;
                }
                chart.Series[nameLines[i1]].ToolTip = "X = #VALX, Y = #VALY";
            }
        }

        public static void AddPoints(this Chart chart, MouseEventArgs e)
        {
            HitTestResult res = chart.HitTest(e.X, e.Y);
            if (res.Series == null) return;

            for(int i = 0; i < points.Count; i++)
            {
                if (points[i].Point.XValue == res.Series.Points[res.PointIndex].XValue &&
                    points[i].Point.YValues[0] == res.Series.Points[res.PointIndex].YValues[0])
                {
                    chart.Series[points[i].IndexLine].Points[points[i].Index].Label = "X=" + points[i].Point.XValue + " Y=" + points[i].Point.YValues[0];
                    chart.Series[points[i].IndexLine].Points[points[i].Index].LabelBackColor = chart.BackColor;

                    chart.Series[points[i].IndexLine].Points[points[i].Index].MarkerColor = Color.Red;
                    chart.Series[points[i].IndexLine].Points[points[i].Index].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[points[i].IndexLine].Points[points[i].Index].MarkerSize = 6;
                    chart.Update();

                    points[i].Point = chart.Series[points[i].IndexLine].Points[points[i].Index];
                    points[i].Visible = true;
                }
            }
        }
    }
}
