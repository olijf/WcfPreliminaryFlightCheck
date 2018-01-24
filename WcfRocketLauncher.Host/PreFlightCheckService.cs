using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfRocketLauncher.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
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
            callback.Done(rocket);
            System.Threading.Thread.Sleep(1000);
            rocket.FlightControl = true;
            callback.Done(rocket);
            System.Threading.Thread.Sleep(6000);
            rocket.WeatherControl = true;
            callback.Done(rocket);
            System.Threading.Thread.Sleep(2000);
            rocket.FlightTrackingControl = true;
            callback.Done(rocket);
        }
    }
}
