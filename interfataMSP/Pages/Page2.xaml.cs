using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace interfataMSP.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : UserControl
    {
        
        public double xValue;
        public double yValue;
        public double zValue;


        SerialProvider serial;


        ObservableCollection<KeyValuePair<double, double>> accelerometru_X = new ObservableCollection<KeyValuePair<double, double>>();
        ObservableCollection<KeyValuePair<double, double>> accelerometru_Y = new ObservableCollection<KeyValuePair<double, double>>();
        ObservableCollection<KeyValuePair<double, double>> accelerometru_Z = new ObservableCollection<KeyValuePair<double, double>>();

        List<ObservableCollection<KeyValuePair<double, double>>> dataSeries = new List<ObservableCollection<KeyValuePair<double, double>>>();
         
        public Page2()
        {
          

            InitializeComponent();
            serial = new SerialProvider();
            dataSeries.Add(accelerometru_X);
            dataSeries.Add(accelerometru_Y);
            dataSeries.Add(accelerometru_Z);
            showColumnChart();
        
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);  
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }


        double i = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            var databuff = serial.GetFirstDataBuff();
            if (databuff != null)
            {
                string[] values = databuff.Split(';');
                xValue = Double.Parse(values[0]);
                yValue = Double.Parse(values[1]);
                zValue = Double.Parse(values[2]);

                accelerometru_X.Add(new KeyValuePair<double, double>(i, xValue));
                accelerometru_Y.Add(new KeyValuePair<double, double>(i, yValue));
                accelerometru_Z.Add(new KeyValuePair<double, double>(i, zValue));
                i += 1;
                //Application.Current.Dispatcher.Invoke(new Action(() => { textBlock.Text = "X:" + xValue + "Y:" + yValue + "Z:" + zValue + "\n"; }));
            }
        }


        private void showColumnChart()
        {
            lineChart.DataContext = dataSeries;
        }
    }

    }

