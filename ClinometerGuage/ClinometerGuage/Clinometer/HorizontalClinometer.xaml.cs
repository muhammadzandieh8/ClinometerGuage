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
    /// Interaction logic for HorizontalClinometer.xaml
    /// </summary>
    public partial class HorizontalClinometer : UserControl
    {
        #region XAxis
        public double XAxis
        {
            get { return (double)GetValue(XAxisProperty); }
            set
            {
                SetValue(XAxisProperty, value);
            }
        }
        public DependencyProperty XAxisProperty = DependencyProperty.Register("XAxis", typeof(double), typeof(HorizontalClinometer), new PropertyMetadata(0d, OnChangeXAxis));
        private static void OnChangeXAxis(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as HorizontalClinometer;
            ct.UpdateXAxis((double)e.NewValue);
        }
        public void UpdateXAxis(double _xAxis)
        {
           
            double size = (int)(radius / LimitDegrees);
            _xAxis *= size;
            if (radius < _xAxis)
            {
                CornerValue.X = radius - CornerLight.Width/2;
            }
            else if (_xAxis < 0 && _xAxis < -1 *radius)
            {
                  CornerValue.X = -(radius - CornerLight.Width / 2);
            }
            else
            {
                CornerValue.X = _xAxis;
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
        public static DependencyProperty ZwidthProperty = DependencyProperty.Register("Zwidth", typeof(int), typeof(HorizontalClinometer), new PropertyMetadata(050, OnChangeZwidth));
        private static void OnChangeZwidth(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as HorizontalClinometer;
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
        public static DependencyProperty ZHeightProperty = DependencyProperty.Register("ZHeight", typeof(int), typeof(HorizontalClinometer), new PropertyMetadata(200, OnChangeZHeight));
        private static void OnChangeZHeight(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as HorizontalClinometer;
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
        public static DependencyProperty ZBorderProperty = DependencyProperty.Register("ZBorder", typeof(int), typeof(HorizontalClinometer), new PropertyMetadata(10, OnChangeZBorder));
        private static void OnChangeZBorder(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as HorizontalClinometer;

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
        public static DependencyProperty ZBubbleSizeProperty = DependencyProperty.Register("ZBubbleSize", typeof(int), typeof(HorizontalClinometer), new PropertyMetadata(23, OnChangeZBubbleSize));
        private static void OnChangeZBubbleSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as HorizontalClinometer;

            ct.UpdateZBubbleSize((int)e.NewValue);
        }
        public void UpdateZBubbleSize(int _ZBubbleSize)
        {
            CornerLight.Width = _ZBubbleSize;
            CornerLight.Height = _ZBubbleSize;
        }
        #endregion
        public int radius;
        public int Width;
        public int LimitDegrees = 36;
        public void DefineLimit()
        {
            Width = (int)MainPlate.Width;
            radius = Width / 2;
            int sizeBetweenLine = (int)MainPlate.Width / 3;
            #region Left Limit
            Border border = new Border
            {
                Background = Brushes.Gray,
                Width = 2,
                Height = MainPlate.Height,
                Margin = new Thickness(sizeBetweenLine, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            LimitLine.Children.Add(border);
            #endregion
            #region Right Limit
            border = new Border
            {
                Background = Brushes.Gray,
                Width = 2,
                Height = MainPlate.Height,
                Margin = new Thickness(0, 0, sizeBetweenLine, 0),
                HorizontalAlignment = HorizontalAlignment.Right
            };
            LimitLine.Children.Add(border);
            #endregion
        }
        public HorizontalClinometer()
        {
            InitializeComponent();

            DefineLimit();
        }
    }
}
