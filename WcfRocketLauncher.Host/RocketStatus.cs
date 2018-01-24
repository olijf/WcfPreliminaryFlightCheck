using System.Runtime.Serialization;

namespace WcfRocketLauncher.Host
{
    [DataContract]
    public class RocketStatus
    {
        private bool _weatherControl;

        [DataMember]
        public bool WeatherControl
        {
            get { return _weatherControl; }
            set { _weatherControl = value; }
        }
        private bool _flightControl;

        [DataMember]
        public bool FlightControl
        {
            get { return _flightControl; }
            set { _flightControl = value; }
        }

        private bool _astronautControl;

        [DataMember]
        public bool AstronautControl
        {
            get { return _astronautControl; }
            set { _astronautControl = value; }
        }

        private bool _flightTrackingControl;

        [DataMember]
        public bool FlightTrackingControl
        {
            get { return _flightTrackingControl; }
            set { _flightTrackingControl = value; }
        }

    }
}
