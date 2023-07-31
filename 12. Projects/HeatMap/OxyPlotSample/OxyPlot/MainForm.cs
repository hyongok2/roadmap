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
                Palette = OxyPalettes.BlueWhiteRed(100),
                Position = AxisPosition.Right
            });

            model.Series.Add(CreateHeatMapSeries());

            model.Series.Add(CreateContour());

            return model;
        }

        private Series CreateHeatMapSeries()
        {
            // generate 1d normal distribution

            var data = new double[5, 5];
            for (int xx = 0; xx < 5; ++xx)
            {
                for (int yy = 0; yy < 5; ++yy)
                {
                    data[yy, xx] = 100;
                }
            }

            data[0, 0] = 101.1;
            data[1, 1] = 100.5;
            data[2, 2] = 99.2;
            data[3, 3] = 99.8;


            var heatMapSeries = new HeatMapSeries
            {
                X0 = 0,
                X1 = 99,
                Y0 = 0,
                Y1 = 99,
                Interpolate = true,
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data,
                EdgeRenderingMode= EdgeRenderingMode.PreferSharpness  
            };

            return heatMapSeries;
        }

        private Series CreateContour()
        {
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

            var data = new double[5, 5];
            for (int xx = 0; xx < 5; ++xx)
            {
                for (int yy = 0; yy < 5; ++yy)
                {
                    data[yy, xx] = 100;
                }
            }

            data[0, 0] = 101.1;
            data[1, 1] = 100.5;
            data[2, 2] = 99.2;
            data[3, 3] = 99.8;

            // Create the contour series
            var contourSeries = new ContourSeries
            {
                Data = data,
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

            return contourSeries;
        }
    }
}