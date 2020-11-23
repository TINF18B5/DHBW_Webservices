using System.ServiceModel;

namespace AuthService
{
    [ServiceContract]
    interface IAuthTest
    {
        [OperationContract]
        AuthName GetAuthName();
    }
}