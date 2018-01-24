using System.ServiceModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using WcfRocketLauncher.Host;

namespace WcfRocketLauncher.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IPreFlightCheckDuplexCallback
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Done(RocketStatus status)
        {
            var view = (DataContext as RocketViewModel);
            view.FlightStatus = status;
            var counter = 0;
            foreach (var item in status.GetType().GetProperties())
            {
                if ((item.GetValue(status) as bool?) == true)
                {
                    counter++;
                }
            }
            Red.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0x0, 0x0));
            if (counter == 2)
            {
                Orange.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0xA5, 0x00));
            }
            else if (counter > 3)
            {
                Green.Fill = new SolidColorBrush(Color.FromRgb(0x00, 0xFF, 0x00));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetAll();
            GetDataOverWcf();
        }

        private void GetDataOverWcf()
        {
            PreFlightCheckClient p = new PreFlightCheckClient(new InstanceContext(this));
            p.StartPreFlightCheck();
            //p.Close();
        }

        private void ResetAll()
        {
            Red.Fill = new SolidColorBrush(Color.FromRgb(0x66, 0x0A, 0x0A));
            Orange.Fill = new SolidColorBrush(Color.FromRgb(0x66, 0x44, 0x0A));
            Green.Fill = new SolidColorBrush(Color.FromRgb(0x0A, 0x66, 0x0A));
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
