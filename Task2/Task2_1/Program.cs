using System;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a, b;

            Console.Write("Input a: ");
            while (!InputValue(out a, 0, 5))
            {
                Console.Write("\nInput a: ");
            }

            Console.Write("Input b: ");
            while (!InputValue(out b, 0, 100))
            {
                Console.Write("\nInput b: ");
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

        public static bool InputValue(out int value, int startRange, int endRange)
        {
            if (!int.TryParse(Console.ReadLine(), out value) || value < startRange || value > endRange)
            {
                Console.WriteLine($"Value should be a number between {startRange} and {endRange}");
                return false;
            }

            return true;
        }
    }
}