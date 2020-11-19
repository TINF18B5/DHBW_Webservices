using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoService
{

    public class EchoService : IEchoService
    {
        public EchoResult Echo(EchoArgument arg)
        {
            return new EchoResult() { Value = arg.Argument + "!" };
        }
    }
}