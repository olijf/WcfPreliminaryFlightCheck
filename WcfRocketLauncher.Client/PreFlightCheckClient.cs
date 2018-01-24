using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
