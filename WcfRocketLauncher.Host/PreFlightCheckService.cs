using System.ServiceModel;

namespace WcfRocketLauncher.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PreFlightCheckService : IPreFlightCheck
    {
        IPreFlightCheckDuplexCallback callback = null;
        private RocketStatus rocket = new RocketStatus();

        public PreFlightCheckService()
        {
            callback = OperationContext.Current.GetCallbackChannel<IPreFlightCheckDuplexCallback>();
        }
        public void StartPreFlightCheck()
        {
            rocket.AstronautControl = true;
            System.Threading.Thread.Sleep(1000);
            callback.Done(rocket);
            rocket.FlightControl = true;
            System.Threading.Thread.Sleep(3000);
            callback.Done(rocket);
            rocket.WeatherControl = true;
            System.Threading.Thread.Sleep(2000);
            callback.Done(rocket);
            rocket.FlightTrackingControl = true;
            System.Threading.Thread.Sleep(500);
            callback.Done(rocket);
        }
    }
}
