using System;

namespace Numerical_Integration_Solver
{
    public class RPNCalculator
    {
        private static void ExceptionPrintOut(string operation)
        {
            try
            {
                ValidOperationInput(operation);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ValidOperationInput(string Operation)
        {
            int numCount = 0;
            int opCount = 0;
            double num;
            if (string.IsNullOrEmpty(Operation))
            {
                throw new InvalidInputException("No input given");
            }
            foreach (var item in Operation.Split(' '))
            {
                if (!string.IsNullOrEmpty(Operation) && double.TryParse(item, out num))
                {
                    numCount += 1;
                }
                else
                {
                    opCount += 1;
                }
            }

            if (opCount == numCount)
            {
                throw new InvalidInputException("Too many operators");
            }
            else if (opCount < numCount - 1)
            {
                throw new InvalidInputException("Not enough operator");
            }
        }

        public static double PostfixCalculator(string oprationInput, double x)
        {
            Stack<double> numStack = new Stack<double>(10);
            double num;
            foreach (var item in oprationInput.Split(' '))
            {
                if (double.TryParse(item, out num))
                {
                    numStack.push(num);
                }
                else if (item.ToLower() == "x")
                {
                    numStack.push(x);
                }
                else
                {
                    //2-3*(7+5) ->2 3 7 5 - * +
                    //according to the func below: (5-7)*3+2
                    double num1 = numStack.pop();
                    double num2 = numStack.pop();
                    double result = Calculate(num1, num2, item);
                    numStack.push(result);
                }
            }
            return numStack.pop();
        }

        private static int Precedence(string opInput)
        {
            if (opInput == "^")
            {
                return 4;
            }
            else if (opInput == "*" || opInput == "/")
            {
                return 3;
            }
            else if (opInput == "+" || opInput == "-")
            {
                return 2;
            }
            else
            {
                return -1;
            }
        }

        private static string Associativity(string opInput)
        {
            if (opInput == "^")
            {
                return "Right";
            }
            else
            {
                return "Left";
            }
        }

        public static string InfixToPostfix(string operation)
        {
            string postfixOutput = "";
            Stack<string> operatorStack = new Stack<string>(10);
            double num;
            foreach (var item in operation.Split(' '))
            {
                if (double.TryParse(item, out num))
                {
                    if (postfixOutput == "")
                    {
                        postfixOutput = item;
                    }

                    else
                    {
                        postfixOutput += item + " ";
                    }
                }
                else if (item.ToLower() == "x")
                {
                    postfixOutput +="x" + " ";
                }
                else if (item == "(")
                {
                    operatorStack.push(item);
                }
                else if (item == ")")
                {
                    while (!operatorStack.isEmpty() && operatorStack.Peek() != "(")
                    {
                        postfixOutput += operatorStack.pop() + " " ;
                    }
                    operatorStack.pop();
                }
                else
                {
                    while (!operatorStack.isEmpty() && operatorStack.Peek() != "("
                            && (Precedence(operatorStack.Peek()) > Precedence(item)
                            || Precedence(operatorStack.Peek()) == Precedence(item)
                            && Associativity(item) == "left"))
                    {
                        postfixOutput += operatorStack.pop() + " ";
                    }
                    operatorStack.push(item);
                }
            }
            while (!operatorStack.isEmpty())
            {
                postfixOutput += operatorStack.pop() + " ";
            }
            postfixOutput += postfixOutput.Trim(' ');
            return postfixOutput;
        }

        //good
        private static double Calculate(double num1, double num2, string operatorInput)
        {
            if (operatorInput == "+")
            {
                return num1 + num2;
            }
            else if (operatorInput == "-")
            {
                return num1 - num2;
            }
            else if (operatorInput == "*")
            {
                return num1 * num2;
            }
            else if (operatorInput == "/")
            {
                return num1 / num2;
            }
            else if (operatorInput == "^")
            {
                return Math.Pow(num1, num2);
            }
            else
            {
                return 0;
            }
        }
    }
}