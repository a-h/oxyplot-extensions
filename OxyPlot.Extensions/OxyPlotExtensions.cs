using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.Extensions
{
    public static class OxyPlotExtensions
    {
        public static void AddScatterSeries(this PlotModel model, IEnumerable<double> xSeries, IEnumerable<double> ySeries)
        {
            model.AddScatterSeries(xSeries, ySeries, OxyColors.Automatic);
        }

        public static void AddScatterSeries(this PlotModel model, IEnumerable<double> xSeries, IEnumerable<double> ySeries, OxyColor color)
        {
            var scatterSeries = new ScatterSeries()
            {
                MarkerFill = color,
                MarkerSize = 1,
            };

            foreach (var item in xSeries.Zip(ySeries, (x, y) => new { x, y }))
            {
                scatterSeries.Points.Add(new ScatterPoint(item.x, item.y));
            }

            model.Series.Add(scatterSeries);
        }

        public static void AddHighlightedPoint(this PlotModel model, double x, double y)
        {
            model.AddHighlightedPoint(x, y, OxyColors.Automatic);
        }

        public static void AddHighlightedPoint(this PlotModel model, double x, double y, OxyColor color)
        {
            var scatterSeries = new ScatterSeries()
            {
                MarkerFill = color,
                MarkerType = MarkerType.Triangle,
                MarkerSize = 5,
            };

            scatterSeries.Points.Add(new ScatterPoint(x, y));

            model.Series.Add(scatterSeries);
        }

        public static void AddLineSeries(this PlotModel model, IEnumerable<double> xSeries, IEnumerable<double> ySeries)
        {
            model.AddLineSeries(xSeries, ySeries, OxyColors.Automatic);
        }

        public static void AddLineSeries(this PlotModel model, IEnumerable<DateTime> xSeries, IEnumerable<double> ySeries)
        {
            model.AddLineSeries(xSeries, ySeries, OxyColors.Automatic);
        }

        public static void AddLineSeries(this PlotModel model, IEnumerable<DateTime> xSeries, IEnumerable<double> ySeries, OxyColor color)
        {
            model.Axes.Add(new DateTimeAxis());
            model.AddLineSeries(xSeries.Select(x => DateTimeAxis.ToDouble(x)), ySeries);
        }

        public static void AddLineSeries(this PlotModel model, IEnumerable<double> xSeries, IEnumerable<double> ySeries, OxyColor color)
        {
            var lineSeries = new LineSeries();

            foreach (var item in xSeries.Zip(ySeries, (x, y) => new { x, y }))
            {
                lineSeries.Points.Add(new DataPoint(item.x, item.y));
            }

            model.Series.Add(lineSeries);
        }

        public static void AddColumnSeries(this PlotModel model, IEnumerable<string> xLabels, IEnumerable<double> ySeries)
        {
            model.AddColumnSeries(xLabels, ySeries, OxyColors.Automatic);
        }

        public static void AddColumnSeries(this PlotModel model, IEnumerable<string> xLabels, IEnumerable<double> ySeries, OxyColor color)
        {
            var axis = new CategoryAxis() { Position = AxisPosition.Bottom };
            axis.Labels.AddRange(xLabels);
            model.Axes.Add(axis);

            var columnSeries = new ColumnSeries()
            {
                FillColor = color,
            };

            columnSeries.Items.AddRange(ySeries.Select(y => new ColumnItem(y)));

            model.Series.Add(columnSeries);
        }
    }
}
