# oxyplot-extensions
A set of extensions to OxyPlot which reduce the amount of code required to graph data.

http://www.nuget.org/packages/oxyplot-extensions/

# Usage

    void Main()	
    {
    	var model = new PlotModel { Title = "Test" };
    	
    	var xseries = new double[] { 1, 2, 3 };
    	var yseries1 = new double[] { 1, 2, 3 };
    	var yseries2 = new double[] { 0.5, 1, 1.5 };
    	
    	model.AddScatterSeries(xseries, yseries1, OxyColors.Red);
    	model.AddHighlightedPoint(2.5, 2.5, OxyColors.Blue);
    	model.AddLineSeries(xseries, yseries2);
    	
    	ShowChart(model);
    }
     
    public static void ShowChart(PlotModel model)
    {
    	var chart = new PlotView();
    	chart.Model = model;
    	chart.Dump();
    }
