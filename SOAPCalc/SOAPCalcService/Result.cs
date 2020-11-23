using System.Runtime.Serialization;

namespace SOAPCalcService
{
    [DataContract]
    class Result
    {
        [DataMember]
        public double Value { get; set; }
    }
}