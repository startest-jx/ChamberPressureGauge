using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Controls.Chart
{
    public partial class MyChart : UserControl
    {
        public MyChart()
        {
            InitializeComponent();
            lvChart.Series = new SeriesCollection();
            lvChart.LegendLocation = LegendLocation.Top;
            lvChart.Zoom = ZoomingOptions.X;
            lvChart.DisableAnimations = true;
            lvChart.Hoverable = false;
            //lvChart.ScrollMode = ScrollMode.XY;
            //lvChart.ScrollBarFill = new SolidColorBrush(MColor.FromArgb(37, 48, 48, 48));
            lvChart.AxisX.Clear();
            lvChart.AxisX.Add(new Axis()
            {
                Title = "时间/s",
                MinValue = 0,
                LabelFormatter = value => $"{value:F2}",
                Separator = new Separator
                {
                    Step = 1d,
                    IsEnabled = false,
                }
            });
            lvChart.AxisY.Clear();
            lvChart.AxisY.Add(new Axis()
            {
                Title = "压力/MPa",
                LabelFormatter = value => $"{value:F5}"
            });
        }
    }
}
