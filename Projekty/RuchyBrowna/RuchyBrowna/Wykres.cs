using OxyPlot.Series;
using OxyPlot;

public class Wykres
{
    public PlotModel MyModel { get; set; }

    public Wykres()
    {
        MyModel = new PlotModel();
    }

    public void DrawChart(double[] data)
    {
        MyModel.Title = "Wykres liniowy";
        MyModel.Series.Clear();
        LineSeries lineSeries = new LineSeries();
        lineSeries.Title = "Dane";
        lineSeries.MarkerType = MarkerType.Circle;
        lineSeries.MarkerSize = 4;
        lineSeries.MarkerStroke = OxyColors.White;
        for (int i = 0; i < data.Length; i++) {
            lineSeries.Points.Add(new DataPoint(i, data[i]));   
        }
        MyModel.Series.Add(lineSeries);
    }
}