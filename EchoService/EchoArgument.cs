using System.Runtime.Serialization;

namespace EchoService
{
    [DataContract]
    public class EchoArgument
    {
        [DataMember] public string Argument { get; set; }
    }
}