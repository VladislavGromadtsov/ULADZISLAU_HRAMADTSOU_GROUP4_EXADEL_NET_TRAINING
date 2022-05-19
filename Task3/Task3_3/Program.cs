using System.Text;
using System.Text.RegularExpressions;

namespace Task3_3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var brackets = string.Empty;

            while (true)
            {
                Console.Write("Input:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Brackets used:");
                brackets = Console.ReadLine();
                if (!string.IsNullOrEmpty(brackets) && CheckBrackets(brackets))
                {
                    break;
                }
            }

            var str = new StringBuilder();
            for (int i = 0; i < brackets?.Length; i++)
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
            for (int i = 0; i < brackets.Length; i += 2)
            {
                var check = str.Where(v => v == brackets[i]).Count() == str.Where(v => v == brackets[i+1]).Count();
                if (!check || str.IndexOf(brackets[i+1]) > str.IndexOf(brackets[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckBrackets(string brackets)
        {
            var allBrackets = "(){}[]<>";
            if (brackets.ToCharArray().All(c => allBrackets.IndexOf(c) != -1))
            {
                if (brackets.Length % 2 == 1)
                {
                    return false;
                }

                for (int i = 0; i < brackets.Length; i += 2)
                {
                    if (allBrackets.IndexOf(brackets[i+1]) - allBrackets.IndexOf(brackets[i]) != 1)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}