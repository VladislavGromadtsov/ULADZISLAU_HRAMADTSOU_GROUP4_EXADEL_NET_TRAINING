using System;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a, b;

            Console.Write("Input a: ");
            if (!InputValue(out a, 0, 5))
            {
                Console.Write("Input a: ");
                InputValue(out a, 0, 5);
            }

            Console.Write("Input b: ");
            if (!InputValue(out b, 0, 100))
            {
                Console.Write("Input b: ");
                InputValue(out b, 0, 100);
            }

            double aResult, bResult;

            aResult = Math.Round(Factorial(a) * 0.05, 2);
            bResult = Math.Round(Math.Log(b), 2);

            Console.Write("Output: ");
            if (aResult > bResult)
            {
                Console.WriteLine($"Number \'a\' = {aResult:F2} and more than number \'b\' = {bResult:F2}");
            }
            else
            {
                Console.WriteLine($"Number \'a\' = {aResult:F2} and less than number \'b\' = {bResult:F2}");
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

        public static bool InputValue(out int value, int startRange, int endRange)
        {
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine($"Value should be a number between {startRange} and {endRange}");
                Console.ReadKey();
                return false;
            }

            if (value < startRange || value > endRange)
            {
                Console.WriteLine($"Value should be a number between {startRange} and {endRange}");
                Console.ReadKey();
                return false;
            }

            return true;
        }
    }
}