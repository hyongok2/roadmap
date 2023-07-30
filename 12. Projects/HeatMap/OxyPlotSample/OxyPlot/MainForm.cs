using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace OxyPlotSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializePlot();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializePlot()
        {
            var plotView = new PlotView
            {
                Dock = DockStyle.Fill
            };

            var model = CreateContourModel();
            plotView.Model = model;

            Controls.Add(plotView);
        }

        private PlotModel CreateContourModel()
        {
            var model = new PlotModel { Title = "Contour Plot Example" };



            // Color axis (the X and Y axes are generated automatically)
            model.Axes.Add(new LinearColorAxis
            {
                Palette = OxyPalettes.Rainbow(100)
            });

            // generate 1d normal distribution
            var singleData = new double[100];
            for (int xx = 0; xx < 100; ++xx)
            {
                singleData[xx] = Math.Exp((-1.0 / 2.0) * Math.Pow(((double)xx - 50.0) / 20.0, 2.0));
            }

            var data = new double[100, 100];
            for (int xx = 0; xx < 100; ++xx)
            {
                for (int yy = 0; yy < 100; ++yy)
                {
                    data[yy, xx] = singleData[xx] * singleData[(yy + 30) % 100] * 100;
                }
            }

            var heatMapSeries = new HeatMapSeries
            {
                X0 = 0,
                X1 = 99,
                Y0 = 0,
                Y1 = 99,
                Interpolate = true,
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data
            };

            model.Series.Add(heatMapSeries);

            // Create data for the contour plot
            int numberOfPoints = 5;
            double[] x = new double[numberOfPoints];
            double[] y = new double[numberOfPoints];
            double[,] z = new double[numberOfPoints, numberOfPoints];

            // Fill the data arrays (replace this with your own data or calculation)
            for (int i = 0; i < numberOfPoints; i++)
            {
                x[i] = i / (double)(numberOfPoints - 1) * 100;
                y[i] = i / (double)(numberOfPoints - 1) * 100;
                for (int j = 0; j < numberOfPoints; j++)
                {
                    z[i, j] = Math.Sin(3 * x[i]) * Math.Cos(5 * y[j]);
                }
            }

            // Create the contour series
            var contourSeries = new ContourSeries
            {
                Data = z,
                ColumnCoordinates = x,
                RowCoordinates = y,
                LabelBackground = OxyColors.White,
                ContourColors = new[]
                {
                    OxyColors.Blue,     // Color for the lowest contour level
                    OxyColors.Green,    // Color for an intermediate contour level
                    OxyColors.Yellow,   // Color for another intermediate contour level
                    OxyColors.Red       // Color for the highest contour level
                }

            };

            // Add the contour series to the plot model
            model.Series.Add(contourSeries);

            return model;
        }
    }
}