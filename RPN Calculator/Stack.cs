using System;

namespace Numerical_Integration_Solver
{
    public class Stack<T> //<T> We can create a stack for any type like str, int, double
    {
        private T[] elements;
        private int numElement;
        private int max;

        public Stack(int size)
        {
            elements = new T[size];
            numElement = 0;
            max = size;
        }

        public void Push(T item)
        {
            if (numElement == max - 1)
            {
                Console.WriteLine("Stack overflow");
            }
            else
            {
                elements[numElement] = item;
                numElement++;
            }
        }

        public T Pop()
        {
            numElement--;
            return elements[numElement];
        }

        public bool IsEmpty()
        {
            return numElement == 0;
        }

        public T Peek()
        {
            return elements[numElement - 1];
        }
    }
}