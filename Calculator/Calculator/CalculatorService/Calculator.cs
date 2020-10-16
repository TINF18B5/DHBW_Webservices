namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public Result Add(Argument args)
        {
            double additionResult = args.Arg1 + args.Arg2;
            return new Result
            {
                Value = additionResult
            };
        }
    }
}