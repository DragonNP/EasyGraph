using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyGraph
{
    public static class Logic
    {
        public static List<List<DataPoint>> Points { get; set; } = new List<List<DataPoint>>();

        public static void PlotLine(this Chart chart, List<double> x, List<string> y, List<string> nameLines)
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

            Points.Clear();
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
                Points.Add(new List<DataPoint>());

                for (int i2 = 0;
                    i2 < (x.Count > yList.Count ? yList.Count : x.Count);
                    i2++, posPoint++)
                {
                    Points[i1].Add(new DataPoint(x[posPoint],
                              double.Parse(yList[i2], System.Globalization.CultureInfo.InvariantCulture)));
                    chart.Series[nameLines[i1]].Points.Add(Points[i1][i2]);
                    chart.Update();
                }
                chart.Series[nameLines[i1]].ToolTip = "X = #VALX, Y = #VALY";
            }
        }

        public static void AddPoints(this Chart chart, MouseEventArgs e)
        {
            HitTestResult res = chart.HitTest(e.X, e.Y);
            if (res.Series != null)
            {

                for (int i1 = 0; i1 < Config.nameLines.Count; i1++)
                {
                    for (int i = 0; i < Points[i1].Count; i++)
                    {
                        if (Points[i1][i].XValue == res.Series.Points[res.PointIndex].XValue &&
                            Points[i1][i].YValues[0] == res.Series.Points[res.PointIndex].YValues[0])
                        {
                            chart.Series[Config.nameLines[i1]].Points[i].Label = "x=" + Points[i1][i].XValue + " y=" + Points[i1][i].YValues[0];
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
    }
}
