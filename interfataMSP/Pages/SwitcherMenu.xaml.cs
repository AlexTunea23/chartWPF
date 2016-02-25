using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace interfataMSP.Pages
{
    /// <summary>
    /// Interaction logic for SwitcherMenu.xaml
    /// </summary>
    public partial class SwitcherMenu : UserControl
    {
        public double xValue;
        public double yValue;
        public double zValue;


        SerialProvider serial;


        ObservableCollection<KeyValuePair<double, double>> accelerometru_X = new ObservableCollection<KeyValuePair<double, double>>();
        ObservableCollection<KeyValuePair<double, double>> accelerometru_Y = new ObservableCollection<KeyValuePair<double, double>>();
        ObservableCollection<KeyValuePair<double, double>> accelerometru_Z = new ObservableCollection<KeyValuePair<double, double>>();

        List<ObservableCollection<KeyValuePair<double, double>>> dataSeries = new List<ObservableCollection<KeyValuePair<double, double>>>();

        public SwitcherMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page1());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page2());
        }
    }
}
