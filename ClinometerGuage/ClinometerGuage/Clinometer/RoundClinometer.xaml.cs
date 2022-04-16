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
    /// Interaction logic for RoundClinometer.xaml
    /// </summary>
    /// 
    public partial class RoundClinometer : UserControl
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
        public DependencyProperty XAxisProperty = DependencyProperty.Register("XAxis", typeof(double), typeof(RoundClinometer), new PropertyMetadata(0d, OnChangeXAxis));
        private static void OnChangeXAxis(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as RoundClinometer;
            ct.UpdateXAxis((double)e.NewValue);
        }
        public void UpdateXAxis(double _xAxis)
        {
            testMamuti(_xAxis, YAxis);
        }
        #endregion XAxis
        #region YAxis
        public double YAxis
        {
            get { return (double)GetValue(YAxisProperty); }
            set
            {
                SetValue(YAxisProperty, value);
            }
        }
        public DependencyProperty YAxisProperty = DependencyProperty.Register("YAxis", typeof(double), typeof(RoundClinometer), new PropertyMetadata(0d, OnChangeYAxis));
        private static void OnChangeYAxis(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as RoundClinometer;
            ct.UpdateYAxis((double)e.NewValue);
        }

        public void UpdateYAxis(double _YAxis)
        {
            testMamuti(XAxis, _YAxis);
        }
        public void testMamuti1(double x1, double y1)
        {
            double size = (int)(radius / LimitDegrees);

            x1 = x1 * (size);
            y1 = y1 * (size);


            double val = x1 / (Math.Sqrt(x1 * x1 + y1 * y1));
            double alpha = Math.Acos(val);
            double x2 = radius * Math.Cos(alpha);
            double y2 = radius * Math.Sin(alpha);


            CornerValue.X = x2;
            CornerValue.Y = y2;

        }

        public void testMamuti(double x1, double y1)
        {
            double size = (int)(radius / LimitDegrees);

            //x1 = x1 * (2.5);
            // y1 = y1 * (size);

            double r = (int)(Math.Sqrt(x1 * x1 + y1 * y1));
            double teta = Math.Acos(x1 / r);
            double x2, y2;
            x2 = radius * Math.Cos(teta);
            y2 = radius * Math.Sin(teta);




            if (r > radius)
            {
                // Quarter1
                if (x1 >= 0 && y1 >= 0)
                {
                    CornerValue.X = x2;
                    CornerValue.Y = y2;
                }
                else
                    // Quarter2
                    if (x1 < 0 && y1 >= 0)
                    {
                        CornerValue.X = -Math.Abs(x2);
                        CornerValue.Y = y2;
                    }
                    else
                        // Quarter3
                        if (x1 < 0 && y1 < 0)
                        {
                            CornerValue.X = -Math.Abs(x2);
                            CornerValue.Y = -Math.Abs(y2);
                        }
                        else
                            // Quarter4
                            if (x1 >= 0 && y1 < 0)
                            {
                                CornerValue.X = x2;
                                CornerValue.Y = -Math.Abs(y2);
                            }
            }
            else
            {
                CornerValue.X = x1;
                CornerValue.Y = y1;
            }
        }
        #endregion
        #region ZSize
        public int ZSize
        {
            get { return (int)GetValue(ZSizeProperty); }
            set
            {
                SetValue(ZSizeProperty, value);
            }
        }
        public static DependencyProperty ZSizeProperty = DependencyProperty.Register("ZSize", typeof(int), typeof(RoundClinometer), new PropertyMetadata(230, OnChangeZSize));
        private static void OnChangeZSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as RoundClinometer;
            
            ct.UpdateZSize((int)e.NewValue);
        }
        public void UpdateZSize(int _ZSize)
        {
            ZSize = _ZSize;
            roundClinometer.Width = ZSize;
            roundClinometer.Height = ZSize ;

            BackPlate.Width = ZSize ;
            BackPlate.Height = ZSize ;
            
            MainPlate.Width = ZSize - ZBorder;
            MainPlate.Height = ZSize - ZBorder;


            DefineLimit();


        }
        public void UpdateZSize()
        {
            roundClinometer.Width = ZSize  ;
            roundClinometer.Height = ZSize  ;

            BackPlate.Width = ZSize;
            BackPlate.Height = ZSize;

            MainPlate.Width = ZSize - ZBorder;
            MainPlate.Height = ZSize - ZBorder;


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
        public static DependencyProperty ZBorderProperty = DependencyProperty.Register("ZBorder", typeof(int), typeof(RoundClinometer), new PropertyMetadata(10, OnChangeZBorder));
        private static void OnChangeZBorder(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as RoundClinometer;

            ct.UpdateZBorder((int)e.NewValue);
        }
        public void UpdateZBorder(int _zBorder)
        {
            ZBorder = _zBorder;
            UpdateZSize();
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
        public static DependencyProperty ZBubbleSizeProperty = DependencyProperty.Register("ZBubbleSize", typeof(int), typeof(RoundClinometer), new PropertyMetadata(23, OnChangeZBubbleSize));
        private static void OnChangeZBubbleSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as RoundClinometer;

            ct.UpdateZBubbleSize((int)e.NewValue);
        }
        public void UpdateZBubbleSize(int _ZBubbleSize)
        {
            CornerLight.Width = _ZBubbleSize;
            CornerLight.Height = _ZBubbleSize;
        }
        #endregion

        public int radius;

        public int LimitDegrees = 36;
        public RoundClinometer()
        {
            InitializeComponent();

            DefineLimit();
        }

        public void DefineLimit()
        {
            Height = (int)MainPlate.Height;
            radius = (int)Height / 2;
            Width = (int)MainPlate.Width;

            //int tempsize = ((int)CornerLight.Width) % 10;
            //tempsize = ((int)CornerLight.Width - tempsize);

            int tempsize =(int)Height/4;
           
            int size = 0;

            //tempsize *= 3;
            size = tempsize;
            StrokeSmall.Width = size;
            StrokeSmall.Height = size;
            size += tempsize;
            StrokeMedium.Width = size;
            StrokeMedium.Height = size;
            size += tempsize;
            StrokeLarge.Width = size;
            StrokeLarge.Height = size;
        }
    }
}
