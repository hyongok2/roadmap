using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrpcWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point? _previousPoint;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void inkCanvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Point currentPoint = e.GetPosition(inkCanvas);

        //        if (_previousPoint.HasValue)
        //        {
        //            Line line = new Line
        //            {
        //                X1 = _previousPoint.Value.X,
        //                Y1 = _previousPoint.Value.Y,
        //                X2 = currentPoint.X,
        //                Y2 = currentPoint.Y,
        //                Stroke = Brushes.Black,
        //                StrokeThickness = 10
        //            };

        //            inkCanvas.Children.Add(line);
        //        }

        //        _previousPoint = currentPoint;
        //    }
        //    else
        //    {
        //        _previousPoint = null;
        //    }
        //}
    }
}
