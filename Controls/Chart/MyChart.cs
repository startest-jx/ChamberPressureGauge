using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using LiveCharts.Events;
using System.Collections.Generic;
using LiveCharts.Geared;
using System.Windows.Media;
using Tools.Configuration;

namespace Controls.Chart
{
    public partial class MyChart : UserControl
    {
        public CartesianChart Chart
        {
            set => _chart = value;
            get => _chart;
        }

        public event DataHoverHandler DataHover
        {
            add => _chart.DataHover += value;
            remove => _chart.DataHover -= value;
        }
        public MyChart()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            _chart.Series = new SeriesCollection();
            _chart.LegendLocation = LegendLocation.Top;
            _chart.Zoom = ZoomingOptions.X;
            _chart.DisableAnimations = true;
            _chart.Hoverable = false;
            //lvChart.ScrollMode = ScrollMode.XY;
            //lvChart.ScrollBarFill = new SolidColorBrush(MColor.FromArgb(37, 48, 48, 48));
            _chart.AxisX.Clear();
            _chart.AxisX.Add(new Axis
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
            _chart.AxisY.Clear();
            _chart.AxisY.Add(new Axis
            {
                Title = "压力/MPa",
                LabelFormatter = value => $"{value:F5}"
            });
        }

        public void DrawPressureLine(List<double> dataList, Configuration config , string title)
        {
            // LiveChart
            //var Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();\
            var lineQuality = (Quality) int.Parse(config.Chart["Quality"].ToString());
            var drawPointCount = int.Parse(config.Chart["PointCount"].ToString());
            var values = new GearedValues<LiveCharts.Defaults.ObservablePoint> { Quality = lineQuality };
            var lineSeries = new GLineSeries
            {
                Fill = Brushes.Transparent,
                //StrokeThickness = 0.5,
                Values = values,
                PointGeometry = null,
                LineSmoothness = 1,
                Title = title,
                AreaLimit = 0,
            };
            //var Series = new Series();
            //Series.ChartType = SeriesChartType.Spline;
            //Series.BorderWidth = 2;
            //Series.Color = Colors[i];
            //Series.LegendText = Channels[i].Name;
            var x = 0;
            int avgX;
            if (drawPointCount == 0)
            {
                avgX = dataList.Count;
            }
            else
            {
                avgX = dataList.Count / drawPointCount;
            }
            foreach (var y in dataList)
            {
                if (x % avgX == 0)
                {
                    var secX = (x - avgX / 2d) / (2000d * 3.2d);
                    var avgY = y;
                    //Series.Points.AddXY(SecX, AvgY);
                    values.Add(new LiveCharts.Defaults.ObservablePoint(secX, avgY));
                }
                x += 1;
            }
            //DataChart.Series.Add(Series);

            Chart.Series.Add(lineSeries);
        }

        public void DrawDigitalLine(List<double> dataList, int drawPointCount, string title)
        {
            // LiveChart
            //var Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
            var values = new GearedValues<LiveCharts.Defaults.ObservablePoint> { Quality = Quality.Low };
            var lineSeries = new GStepLineSeries()
            {
                Fill = Brushes.Transparent,
                //StrokeThickness = 0.5,
                Values = values,
                PointGeometry = null,
                Title = title,
            };
            //var Series = new Series();
            //Series.ChartType = SeriesChartType.Spline;
            //Series.BorderWidth = 2;
            //Series.Color = Colors[i];
            //Series.LegendText = Channels[i].Name;
            var x = 0;
            int avgX;
            if (drawPointCount == 0)
            {
                avgX = dataList.Count;
            }
            else
            {
                avgX = dataList.Count / drawPointCount;
            }
            foreach (var y in dataList)
            {
                if (x % avgX == 0)
                {
                    var secX = (x - avgX / 2d) / (2000d * 3.2d);
                    var avgY = y;
                    //Series.Points.AddXY(SecX, AvgY);
                    values.Add(new LiveCharts.Defaults.ObservablePoint(secX, avgY));
                }
                x += 1;
            }
            //DataChart.Series.Add(Series);

            Chart.Series.Add(lineSeries);
        }

        public void Import()
        {
            
        }
    }
}
