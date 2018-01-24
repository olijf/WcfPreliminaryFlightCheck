using System.ServiceModel;

namespace WcfRocketLauncher.Host
{
    [ServiceContract(SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IPreFlightCheckDuplexCallback))]
    public interface IPreFlightCheck
    {
        [OperationContract(IsOneWay = true)]
        void StartPreFlightCheck();
    }

    public interface IPreFlightCheckDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Done(RocketStatus status);
    }
}
