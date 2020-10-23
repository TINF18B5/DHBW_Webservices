using System;
using System.ServiceModel;

namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public Result Add(Argument args)
        {
            var identity = System.ServiceModel.ServiceSecurityContext.Current.PrimaryIdentity;
            if (identity.Name == @"LUKAS_DESKTOP\Hugo")
            {
                double additionResult = args.Arg1 + args.Arg2;
                return new Result
                {
                    Value = additionResult
                };
            }
            throw new AddressAccessDeniedException();

        }
    }
}