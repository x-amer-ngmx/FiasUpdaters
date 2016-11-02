using System.ServiceModel;

namespace FiasUpdater
{
    [ServiceContract(Name = "IFiasReal",SessionMode = SessionMode.Required)]
    public interface IRealisation
    {
        [OperationContract(Name = "Runable")]
        void ActulisDateRUN(string dir);
    }
}
