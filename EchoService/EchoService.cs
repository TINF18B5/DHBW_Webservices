using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace EchoService
{

    public class EchoService : IEchoService
    {
        public EchoResult Echo(EchoArgument arg)
        {
            var identity = ServiceSecurityContext.Current.PrimaryIdentity;
            if (identity.Name == @"DESKTOP-UVKMM87\test")
            {
                return new EchoResult() { Value = arg.Argument + "!" };
            }
            throw new AddressAccessDeniedException();
        }
    }
}