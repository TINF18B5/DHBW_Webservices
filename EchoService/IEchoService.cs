using System.ServiceModel;

namespace EchoService
{
    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        EchoResult Echo(EchoArgument arg);
    }
}