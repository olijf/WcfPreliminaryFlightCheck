using System.ServiceModel;
using WcfRocketLauncher.Host;

namespace WcfRocketLauncher.Client
{
    class PreFlightCheckClient : ClientBase<IPreFlightCheck>, IPreFlightCheck
    {
        public void StartPreFlightCheck()
        {
            Channel.StartPreFlightCheck();
        }
    }
}
