using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Integration_Solver
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                double a, b;
                double[] boundaries;
                Console.WriteLine("Integral calculator");

                Console.WriteLine("1. Write coefficients of polynomial function");
                Console.WriteLine("2. Write polynomial function ");
                Console.Write("Enter your choice: ");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Please write the coefficients: ");
                        string coefficientInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(coefficientInput)) throw new FormatException();

                        string[] spltCoefficient = coefficientInput.Split(' ');

                        List<int> coefficients = new List<int>(); //1 2 3 -4
                        for (int i = 0; i < spltCoefficient.Length; i++)
                        {
                            coefficients.Add(int.Parse(spltCoefficient[i]));
                        }
                        Console.WriteLine("\nPlease write the boudaries of integration:");
                        Console.Write("a = ");
                        a = double.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        b = double.Parse(Console.ReadLine());
                        boundaries = new double[2] { a, b };
                        ICalculateIntegral form = new IntegralsOfPolynomials(coefficients, boundaries);
                        form.DisplayFunction();
                        Console.WriteLine(form.TrapezodalMethod(1000));
                        Console.WriteLine(form.SimpsonMethod(1000));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please write the function:");
                        string infixFunction = Console.ReadLine();
                        Console.WriteLine("\nPlease write the boudaries of integration:");
                        Console.Write("a = ");
                        a = double.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        b = double.Parse(Console.ReadLine());
                        boundaries = new double[2] { a, b };
                        IntegralsOfPolynomials form2 = new IntegralsOfPolynomials(boundaries);
                        Console.WriteLine(form2.SimpsonMethod(infixFunction, 1000));
                        Console.WriteLine(form2.TrapezodalMethod(infixFunction, 1000));

                        break;
                    default:
                        break;
                }

                Console.Write("\nDo you want to continue(y = yes/ anykey = no): ");
                if (isContinue(Console.ReadLine()))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }


        }

        public static bool isContinue(string ans)
        {
            return (ans.ToLower() == "y") ? true : false;

        }
    }
}
