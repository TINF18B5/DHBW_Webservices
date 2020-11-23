using System.ServiceModel;

namespace SOAPCalcService
{
    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        Result Multiply(Argument arg);
    }
}