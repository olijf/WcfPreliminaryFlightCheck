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

        public PreFlightCheckService()
        {
            callback = OperationContext.Current.GetCallbackChannel<IPreFlightCheckDuplexCallback>();
        }
        private RocketStatus rocket = new RocketStatus();
        public void StartPreFlightCheck()
        {

        }
    }
}
