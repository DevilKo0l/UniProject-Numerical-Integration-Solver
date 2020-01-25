using System;
using System.Collections.Generic;

namespace Numerical_Integration_Solver
{
    class IntegralsOfPolynomials : ICalculateIntegral
    {

        public List<int> polynomialCoefficients { get; set; }

        private int sizeFunc;

        public IntegralsOfPolynomials(List<int> newPolynomialCoeffients)
        {
            polynomialCoefficients = newPolynomialCoeffients;
            sizeFunc = polynomialCoefficients.Count;
        }

        public void DisplayFunction()
        {
            int exponent = polynomialCoefficients.Count - 1;
            Console.WriteLine("The function you'have enterd: ");

            string polyFunction = $"f(x) = {polynomialCoefficients[0]}x^{exponent}";
            exponent--;
            for (int i = 1; i < sizeFunc - 1; i++)
            {
                int coeff = polynomialCoefficients[i];
                _ = (coeff > 0) ?
                    polyFunction += $" + {coeff}x^{exponent}" :
                    polyFunction += $" - {Math.Abs(coeff)}x^{exponent}";

                exponent--;
            }
            int constPoly = polynomialCoefficients[sizeFunc - 1];
            _ = (constPoly > 0) ?
            polyFunction += $" + {constPoly}" :
            polyFunction += $" - {Math.Abs(constPoly)}";
            Console.WriteLine(polyFunction);
        }
        private double GetFunctionValue(double n)
        {
            int exponent = polynomialCoefficients.Count - 1;
            double result = 0;
            for (int i = 0; i < sizeFunc; i++)
            {
                result += polynomialCoefficients[i] * Math.Pow(n, exponent);
                exponent--;
            }
            return result;
        }
        public double SimpsonMethod(double[] boundaries, int numberOfInterval)
        {
            double h = (boundaries[1] - boundaries[0]) / numberOfInterval;
            double I =  GetFunctionValue(boundaries[0]) + GetFunctionValue(boundaries[1]);
            for (int i = 1; i < numberOfInterval; i++)
            {
                int coefficient = (i % 2 == 0) ? 2 : 4;
                I += coefficient * GetFunctionValue(boundaries[0] + i * h);
            }
            return (h*I)/3;

        }
        
        public double TrapezodalMethod(double[] boundaries, int numberOfInterval)
        {
            double h = (boundaries[1] - boundaries[0]) / numberOfInterval;
            double I =  GetFunctionValue(boundaries[0]) + GetFunctionValue(boundaries[1]);

            for (int i = 1; i <numberOfInterval-1; i++)
            {
                I += 2*GetFunctionValue(boundaries[0] + i * h);
            }
            return (h*I)/2;
        }
    }
}
