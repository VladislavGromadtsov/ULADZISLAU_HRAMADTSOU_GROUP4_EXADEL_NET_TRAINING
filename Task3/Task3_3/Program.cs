using System;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Task3_3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var inputFlag = true;
            var input = string.Empty;
            var brackets = string.Empty;

            while (inputFlag)
            {
                Console.Write("Input:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    inputFlag = false;
                }
            }
            inputFlag = true;

            while (inputFlag)
            {
                Console.Write("Brackets used:");
                brackets = Console.ReadLine();
                if (brackets is not null && brackets.Length % 2 == 0)
                {
                    inputFlag = false;
                }
            }

            var str = new StringBuilder();
            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] != ']')
                {
                    str.Append(brackets[i]);
                }
                else
                {
                    str.Append($"\\{brackets[i]}");
                }
            }

            var regex = new Regex(@$"[^{ str }]");
            var target = string.Empty;

            var result = regex.Replace(input, target);

            Console.Write("Output: ");
            Console.WriteLine($"{result} - {CheckString(result, brackets)}");
        }

        private static bool CheckString(string str, string brackets)
        {
            var counter = new int[brackets.Length];

            for (int i = 0; i < str.Length; i++)
            {
                var index = brackets.IndexOf(str[i]);
                if (index != -1)
                {
                    counter[index]++;
                }
            }

            for (int i = 0; i < counter.Length / 2; i += 2)
            {
                if (counter[i] != counter[i+1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}