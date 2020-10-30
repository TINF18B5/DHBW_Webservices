using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GRPCCalculator.Protos;

namespace GRPCCalculator.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        public override Task<Result> Add(Argument request, ServerCallContext context)
        {
            return Task.FromResult(new Result()
            {
                Result_ = request.Arg1 + request.Arg2
            });
        }
    }
}
