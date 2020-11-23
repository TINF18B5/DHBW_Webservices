using System.Runtime.Serialization;

namespace SOAPCalcService
{
    [DataContract]
    class Argument
    {
        [DataMember]
        public double Arg1 { get; set; }
        [DataMember]
        public double Arg2 { get; set; }
    }
}