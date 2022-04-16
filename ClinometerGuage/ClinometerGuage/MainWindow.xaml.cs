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

namespace ClinometerGuage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void sld_Horizontal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Horizontalclinometer.CornerValue.X = sld_Horizontal.Value;
            //rndclinometer.CornerValue.X = sld_Horizontal.Value;
            Horizontalclinometer.XAxis = sld_Horizontal.Value;
            rndclinometer.XAxis = sld_Horizontal.Value;

            lbl_Xaxis.Content = sld_Horizontal.Value.ToString("00.0");
        }
        private void sld_Vertical_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //verticalclinometer.CornerValue.Y = sld_Vertical.Value;
            //rndclinometer.CornerValue.Y = sld_Vertical.Value;
            verticalclinometer.YAxis = sld_Vertical.Value;
            rndclinometer.YAxis = sld_Vertical.Value;

            lbl_Yaxis.Content = sld_Vertical.Value.ToString("00.0");
        }
        double X = 0.0;
    }
}
