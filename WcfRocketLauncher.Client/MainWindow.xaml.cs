using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WcfRocketLauncher.Client
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

        private async void ComputeStuffAsync()
        {
            Red.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0x00, 0x00));
            var WeatherTask = new Task(() => Thread.Sleep(2000));
            var CosmonautsTask = new Task(() => Thread.Sleep(3000));
            var FlightcontrolTask = new Task(() => Thread.Sleep(1000));
            var FlighttrackingTask = new Task(() => Thread.Sleep(800));

            var rocketStatus = (DataContext as RocketViewModel).FlightStatus;
            List<Task> t = new List<Task>
            {
                WeatherTask,
                CosmonautsTask,
                FlightcontrolTask,
                FlighttrackingTask
            };
            
            WeatherTask.ContinueWith(_ => rocketStatus.WeatherControl = true);
            CosmonautsTask.ContinueWith(_ => rocketStatus.AstronautControl = true);
            FlightcontrolTask.ContinueWith(_ => rocketStatus.FlightControl = true);
            FlighttrackingTask.ContinueWith(_ => rocketStatus.FlightTrackingControl = true);

            t.ForEach(x => x.Start());

            await Task.WhenAny(t);
            Orange.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0xA5, 0x00));

            await Task.WhenAll(t);
            Green.Fill = new SolidColorBrush(Color.FromRgb(0x00, 0xFF, 0x00));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetAll();
            ComputeStuffAsync();
        }

        private void ResetAll()
        {
            Red.Fill = new SolidColorBrush(Color.FromRgb(0x66,0x0A,0x0A));
            Orange.Fill = new SolidColorBrush(Color.FromRgb(0x66,0x44,0x0A));
            Green.Fill = new SolidColorBrush(Color.FromRgb(0x0A,0x66,0x0A));           
            //Orange.Fill = Brushes.Black;
            //Green.Fill = Brushes.Black;
            var rocketStatus = (DataContext as RocketViewModel).FlightStatus;
            rocketStatus.WeatherControl = false;
            rocketStatus.AstronautControl = false;
            rocketStatus.FlightControl = false;
            rocketStatus.FlightTrackingControl = false;
        }   
    }       
}           
