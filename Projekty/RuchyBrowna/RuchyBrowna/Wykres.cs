using OxyPlot;
using OxyPlot.Series;

public class Wykres
{
    public PlotModel marcovModel { get; set; } = new PlotModel();
    public PlotModel brownModel { get; set; } = new PlotModel();
    public PlotModel marcov2DModel { get; set; } = new PlotModel();

    public void DrawChart(PlotModel model, string title, double[] data)
    {
        model.Title = title;
        var series = new LineSeries();
        for (int i = 0; i < data.Length; i++)
        {
            series.Points.Add(new DataPoint(i, data[i]));
        }
        model.Series.Clear();
        model.Series.Add(series);
    }

    public void DrawChart2D(PlotModel model, string title, double[] xData, double[] yData)
    {
        model.Title = title;
        var series = new LineSeries();
        for (int i = 0; i < xData.Length; i++)
        {
            series.Points.Add(new DataPoint(xData[i], yData[i]));
        }
        model.Series.Clear();
        model.Series.Add(series);
    }
}