using System;

namespace Numerical_Integration_Solver
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string messenge) : base(string.Format("Wrong equation: {0}", messenge))
        {
        }
    }
}