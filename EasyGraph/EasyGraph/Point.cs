using System.Windows.Forms.DataVisualization.Charting;

namespace EasyGraph.Logic
{
    public class Points
    {
        public int IndexLine { get; set; } = 0;
        public int Index { get; set; } = 0;
        public bool Visible { get; set; } = false;
        public DataPoint Point { get; set; } = null;
        private static int IndexDef = 0;

        public Points(int indexLine, DataPoint point, int index)
        {
            IndexLine = indexLine;
            Index = index;
            Point = point;
        }

        public Points(int indexLine, DataPoint point)
        {
            IndexLine = indexLine;
            Index = IndexDef++;
            Point = point;
        }
    }
}
