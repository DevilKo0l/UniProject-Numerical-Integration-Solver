using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Integration_Solver
{
    class IntegralsOfPolynomials : ICalculateIntegral
    {
        public int[] boundaries { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> polynomialCoefficients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int exp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DisplayFunction()
        {
            throw new NotImplementedException();
        }

        public int SimpsonMethod()
        {
            throw new NotImplementedException();
        }

        public int TrapezodalMethod()
        {
            throw new NotImplementedException();
        }
    }
}
