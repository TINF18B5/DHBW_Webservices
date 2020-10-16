using System.ServiceModel;

namespace CalculatorService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        Result Add(Argument args);
    }
}
