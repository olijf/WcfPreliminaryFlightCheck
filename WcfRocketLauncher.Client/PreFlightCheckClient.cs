using System.ServiceModel;
using WcfRocketLauncher.Host;

namespace WcfRocketLauncher.Client
{
    class PreFlightCheckClient : DuplexClientBase<IPreFlightCheck>, IPreFlightCheck
    {
        public PreFlightCheckClient(InstanceContext callbackInstance) : base(callbackInstance)
        {
        }

        public void StartPreFlightCheck()
        {
            Channel.StartPreFlightCheck();
        }
    }
}
