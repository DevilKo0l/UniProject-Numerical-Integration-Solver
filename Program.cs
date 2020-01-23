using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Integration_Solver
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> coeeficient = new List<int>() { 1, 2, 3, -4 };
            int[] boundaries = new int[2] { 0, 3 };
            ICalculateIntegral form = new  IntegralsOfPolynomials(coeeficient);
            form.DisplayFunction();
            
            Console.WriteLine(form.TrapezodalMethod(boundaries,2));
            Console.WriteLine(form.TrapezodalMethod(boundaries,2));

        }
    }
}
