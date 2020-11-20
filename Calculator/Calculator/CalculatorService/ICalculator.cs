using System.ServiceModel;

namespace CalculatorService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        Result Add(Argument args);
        [OperationContract]
        Result Subtract(Argument args);
        [OperationContract]
        Result Multiply(Argument args);
        [OperationContract]
        Result Divide(Argument args);
    }
}
