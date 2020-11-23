namespace SOAPCalcService
{
    class Calculator : ICalculator
    {
        public Result Multiply(Argument arg)
        {
            return new Result() { Value = arg.Arg1 * arg.Arg2 };
        }
    }
}