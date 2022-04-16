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
    /// Interaction logic for VerticalClinometer.xaml
    /// </summary>
    public partial class VerticalClinometer : UserControl
    {
        #region YAxis
        public double YAxis
        {
            get { return (double)GetValue(YAxisProperty); }
            set
            {
                SetValue(YAxisProperty, value);
            }
        }
        public DependencyProperty YAxisProperty = DependencyProperty.Register("YAxis", typeof(double), typeof(VerticalClinometer), new PropertyMetadata(0d, OnChangeYAxis));
        private static void OnChangeYAxis(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as VerticalClinometer;
            ct.UpdateYAxis((double)e.NewValue);
        }
        public void UpdateYAxis(double _YAxis)
        {

            double size = (int)(radius / LimitDegrees);
            _YAxis *= size;
            if (radius < _YAxis)
            {
                CornerValue.Y = radius - CornerLight.Width / 2;
            }
            else if (_YAxis < 0 && _YAxis < -1 * radius)
            {
                CornerValue.Y = -(radius - CornerLight.Width / 2);
            }
            else
            {
                CornerValue.Y = _YAxis;
            }
        }
        #endregion
        #region Zwidth
        public int Zwidth
        {
            get { return (int)GetValue(ZwidthProperty); }
            set
            {
                SetValue(ZwidthProperty, value);
            }
        }
        public static DependencyProperty ZwidthProperty = DependencyProperty.Register("Zwidth", typeof(int), typeof(VerticalClinometer), new PropertyMetadata(200, OnChangeZwidth));
        private static void OnChangeZwidth(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as VerticalClinometer;
            ct.UpdateZwidth((int)e.NewValue);
        }
        public void UpdateZwidth(int _Zwidth)
        {
            BackPlate.Width = _Zwidth;
            MainPlate.Width = _Zwidth - ZBorder;

            LimitLine.Children.Clear();
            DefineLimit();
        }
        #endregion
        #region ZHeight
        public int ZHeight
        {
            get { return (int)GetValue(ZHeightProperty); }
            set
            {
                SetValue(ZHeightProperty, value);
            }
        }
        public static DependencyProperty ZHeightProperty = DependencyProperty.Register("ZHeight", typeof(int), typeof(VerticalClinometer), new PropertyMetadata(050, OnChangeZHeight));
        private static void OnChangeZHeight(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as VerticalClinometer;
            ct.UpdateZHeight((int)e.NewValue);
        }
        public void UpdateZHeight(int _ZHeight)
        {
            BackPlate.Height = _ZHeight;
            MainPlate.Height = _ZHeight - ZBorder;
            ZHeight = _ZHeight;
            LimitLine.Children.Clear();
            DefineLimit();
        }
        #endregion
        #region ZBorder
        public int ZBorder
        {
            get { return (int)GetValue(ZBorderProperty); }
            set
            {
                SetValue(ZBorderProperty, value);
            }
        }
        public static DependencyProperty ZBorderProperty = DependencyProperty.Register("ZBorder", typeof(int), typeof(VerticalClinometer), new PropertyMetadata(10, OnChangeZBorder));
        private static void OnChangeZBorder(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as VerticalClinometer;

            ct.UpdateZBorder((int)e.NewValue);
        }
        public void UpdateZBorder(int _zBorder)
        {
            ZBorder = _zBorder;
        }
        #endregion
        #region ZBubbleSize
        public int ZBubbleSize
        {
            get { return (int)GetValue(ZBubbleSizeProperty); }
            set
            {
                SetValue(ZBubbleSizeProperty, value);
            }
        }
        public static DependencyProperty ZBubbleSizeProperty = DependencyProperty.Register("ZBubbleSize", typeof(int), typeof(VerticalClinometer), new PropertyMetadata(23, OnChangeZBubbleSize));
        private static void OnChangeZBubbleSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as VerticalClinometer;

            ct.UpdateZBubbleSize((int)e.NewValue);
        }
        public void UpdateZBubbleSize(int _ZBubbleSize)
        {
            CornerLight.Width = _ZBubbleSize;
            CornerLight.Height = _ZBubbleSize;
        }
        #endregion

        public int radius;
        public int Height;
        public int LimitDegrees = 36;
        public void DefineLimit()
        {
            Height = (int)MainPlate.Height;
            radius = Height / 2;
            int sizeBetweenLine = Height / 3;
            #region UpLimit
            Border border = new Border
            {
                Background = Brushes.Gray,
                Width = MainPlate.Width,
                Height = 2,
                Margin = new Thickness(0, sizeBetweenLine, 0, 0),
                VerticalAlignment = VerticalAlignment.Top
            };
            LimitLine.Children.Add(border);
            #endregion
            #region DownLimit
            border = new Border
            {
                Background = Brushes.Gray,
                Width = MainPlate.Width,
                Height = 2,
                Margin = new Thickness(0, 0, 0, sizeBetweenLine),
                VerticalAlignment = VerticalAlignment.Bottom
            };
            LimitLine.Children.Add(border);
            #endregion
        }
        public VerticalClinometer()
        {
            InitializeComponent();

            DefineLimit();
        }
    }
}
