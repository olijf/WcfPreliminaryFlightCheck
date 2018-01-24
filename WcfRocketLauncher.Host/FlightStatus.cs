using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WcfRocketLauncher.Client
{
    class RocketStatus : INotifyPropertyChanged
    {
        private bool _weatherControl;
        public bool WeatherControl
        {
            get { return _weatherControl; }
            set { _weatherControl = value; OnPropertyChanged(); }
        }
        private bool _flightControl;

        public bool FlightControl
        {
            get { return _flightControl; }
            set { _flightControl = value; OnPropertyChanged(); }
        }

        private bool _astronautControl;

        public bool AstronautControl
        {
            get { return _astronautControl; }
            set { _astronautControl = value; OnPropertyChanged(); }
        }

        private bool _flightTrackingControl;

        public bool FlightTrackingControl
        {
            get { return _flightTrackingControl; }
            set { _flightTrackingControl = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
