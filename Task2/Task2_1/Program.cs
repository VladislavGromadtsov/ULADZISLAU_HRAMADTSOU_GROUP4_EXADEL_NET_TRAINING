using System;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a, b;
            bool flagA,flagB;

            Console.Write("Input a: ");
            (flagA, a) = InputValue(0, 5);
            while (!flagA)
            {
                Console.Write("\nInput a: ");
                (flagA, a) = InputValue(0, 5);
            }

            Console.Write("Input b: ");
            (flagB, b) = InputValue(0, 100);
            while (!flagB)
            {
                Console.Write("\nInput b: ");
                (flagB, b) = InputValue(0, 100);
            }

            double aResult, bResult;

            aResult = Math.Round(Factorial(a) * 0.05, 2);
            bResult = Math.Round(Math.Log(b), 2);

            Console.Write("Output: ");
            if (aResult > bResult)
            {
                Console.WriteLine($"\"Number \'a\' = {aResult:F2} and more than number \'b\' = {bResult:F2}\"");
            }
            else if (aResult == bResult)
            {
                Console.WriteLine($"\"Number \'a\' = {aResult:F2} and equals to number \'b\' = {bResult:F2}\"");
            }
            else
            {
                Console.WriteLine($"\"Number \'a\' = {aResult:F2} and less than number \'b\' = {bResult:F2}\"");
            }
        }

        private static double Factorial(int n)
        {
            double res = 1;

            if (n == 0)
            {
                return res;
            }

            while (n != 1)
            {
                res *= n;
                n -= 1;
            }

            return res;
        }

        public static (bool, int) InputValue(int startRange, int endRange)
        {
            int value;

            if (!int.TryParse(Console.ReadLine(), out value) || value < startRange || value > endRange)
            {
                Console.WriteLine($"Value should be a number between {startRange} and {endRange}");
                return (false, 0);
            }

            return (true, value);
        }
    }
}