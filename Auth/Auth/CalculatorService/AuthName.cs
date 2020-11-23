using System.Runtime.Serialization;

namespace AuthService
{
    [DataContract]
    class AuthName
    {
        [DataMember] public string Name { get; set; }

    }
}