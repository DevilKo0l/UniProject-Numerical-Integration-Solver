using System;
using System.Collections.Generic;

namespace Numerical_Integration_Solver
{
    class IntegralsOfPolynomials : ICalculateIntegral
    {

        public List<int> polynomialCoefficients { get; set; }
        double[] _boundaries;
        private int sizeFunc;

        public IntegralsOfPolynomials(List<int> newPolynomialCoeffients, double[] boundaries)
        {
            polynomialCoefficients = newPolynomialCoeffients;
            sizeFunc = polynomialCoefficients.Count;
            _boundaries = boundaries;
        }

        public IntegralsOfPolynomials(double[] boundaries)
        {
            _boundaries = boundaries;
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
        private double GetFunctionValue(double x)
        {
            int exponent = polynomialCoefficients.Count - 1;
            double result = 0;
            for (int i = 0; i < sizeFunc; i++)
            {
                result += polynomialCoefficients[i] * Math.Pow(x, exponent);
                exponent--;
            }
            return result;
        }

        private double GetFunctionValue(string infixFunction,double x)
        {
            string postfixFunction = RPNCalculator.InfixToPostfix(infixFunction, x);
            return RPNCalculator.PostfixCalculator(postfixFunction);
        }
        public double SimpsonMethod(int numberOfInterval)
        {
            double h = (_boundaries[1] - _boundaries[0]) / numberOfInterval;
            double I =  GetFunctionValue(_boundaries[0]) + GetFunctionValue(_boundaries[1]);
            for (int i = 1; i < numberOfInterval; i++)
            {
                int coefficient = (i % 2 == 0) ? 2 : 4;
                I += coefficient * GetFunctionValue(_boundaries[0] + i * h);
            }
            return (h*I)/3;

        }
        
        public double TrapezodalMethod(int numberOfInterval)
        {
            double h = (_boundaries[1] - _boundaries[0]) / numberOfInterval;
            double I =  GetFunctionValue(_boundaries[0]) + GetFunctionValue(_boundaries[1]);

            for (int i = 1; i <numberOfInterval-1; i++)
            {
                I += 2*GetFunctionValue(_boundaries[0] + i * h);
            }
            return (h*I)/2;
        }

        public double SimpsonMethod(string infixFunction,int numberOfInterval)
        {
            double h = (_boundaries[1] - _boundaries[0]) / numberOfInterval;
            double I = GetFunctionValue(infixFunction,_boundaries[0]) + GetFunctionValue(infixFunction,_boundaries[1]);
            for (int i = 1; i < numberOfInterval; i++)
            {
                int coefficient = (i % 2 == 0) ? 2 : 4;
                I += coefficient * GetFunctionValue(infixFunction,_boundaries[0] + i * h);
            }
            return (h * I) / 3;

        }

        public double TrapezodalMethod(string infixFunction,int numberOfInterval)
        {
            double h = (_boundaries[1] - _boundaries[0]) / numberOfInterval;
            double I = GetFunctionValue(infixFunction,_boundaries[0]) + GetFunctionValue(infixFunction,_boundaries[1]);

            for (int i = 1; i < numberOfInterval - 1; i++)
            {
                I += 2 * GetFunctionValue(infixFunction,_boundaries[0] + i * h);
            }
            return (h * I) / 2;
        }
    }
}
