using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyGraph
{
    public static class EasyChart
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
