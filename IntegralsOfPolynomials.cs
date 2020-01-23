using System;
using System.Collections.Generic;

namespace Numerical_Integration_Solver
{
    class IntegralsOfPolynomials : ICalculateIntegral    {
        
        public List<int> polynomialCoefficients { get; set; }

        private int exponent;

        private int sizeFunc;

        public IntegralsOfPolynomials(List<int> newPolynomialCoeffients)
        {
            polynomialCoefficients = newPolynomialCoeffients;
            exponent = polynomialCoefficients.Count - 1;
            sizeFunc = polynomialCoefficients.Count;
        }
        
        public void DisplayFunction()
        {
            Console.WriteLine("The function you'have enterd: ");            
            
            string polyFunction = $"f(x) = {polynomialCoefficients[0]}x^{exponent}";
            exponent--;
            for (int i = 1; i <sizeFunc-1; i++)
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

        public double SimpsonMethod(int[] boundaries, double n)
        {
            double h = (boundaries[1] - boundaries[0]) / n;
            double I = h / 2 * (getFunctionValue(boundaries[0])+ getFunctionValue(boundaries[1]));
            for (int i = 0; i < n; i++)
            {
                int coefficient = (i / 2 == 0) ? 2 : 4;
                I += coefficient * getFunctionValue(boundaries[0] + i * h);
            }
            return I;

        }

        private double getFunctionValue(double n)
        {
            exponent = polynomialCoefficients.Count - 1;
            double result = 0;
            for (int i = 0; i < sizeFunc; i++)
            {
                result += polynomialCoefficients[i] * Math.Pow(n, exponent);
                exponent--;
            }
            return result;
        }
        public double TrapezodalMethod(int[] boundaries,double n)
        {
            double h = (boundaries[1] - boundaries[0]) / n;
            double I = h / 2 * (getFunctionValue(boundaries[0]) + getFunctionValue(boundaries[1]));

            for (int i = 0; i < n; i++)
            {
                I += h * getFunctionValue(boundaries[0] + i * h);
            }
            return I;
        }
    }
}
