﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WcfRocketLauncher.Client
{
    class RocketViewModel : INotifyPropertyChanged
    {
        private RocketStatus _flightStatus = new RocketStatus();

        public RocketStatus FlightStatus
        {
            get { return _flightStatus; }
            set { _flightStatus = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}