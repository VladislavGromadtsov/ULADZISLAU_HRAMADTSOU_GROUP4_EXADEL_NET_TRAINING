using System;
using System.Text;
using System.Linq;

namespace Task3_1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, LinkedList<string>> dict = FillDictKeys();
            string[] lastnames;

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    lastnames = input.Trim().Split(", ");
                    var flag = true;
                    foreach (var lastname in lastnames)
                    {
                        if (!lastname.ToCharArray().All(char.IsLetter) || lastname.Length == 0)
                        {
                            flag = false;
                        }
                    }

                    if (flag)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter name by name by using comma correctly");
                    }
                }
            }

            Queue<string> inputQueue = new Queue<string>(lastnames);

            if (inputQueue.Count != 0)
            {
                foreach (var name in from string name in inputQueue
                                     where char.IsLetter(name[0])
                                     select name)
                {
                    dict[char.ToLowerInvariant(name[0])].AddLast(name);
                }
            }

            Console.WriteLine("Output:");
            PrintDict(dict);
        }

        private static void PrintDict(Dictionary<char, LinkedList<string>> dict)
        {
            foreach (char letter in dict.Keys)
            {
                StringBuilder str = new StringBuilder($"{letter}: ");
                foreach (string value in dict[letter])
                {
                    str.Append($"\"{value}\"\t");
                }

                Console.WriteLine(str.ToString());
            }
        }

        private static Dictionary<char, LinkedList<string>> FillDictKeys()
        {
            var dict = new Dictionary<char, LinkedList<string>>();
            for (int i = 97; i <= 122; i++)
            {
                dict.Add((char)i, new LinkedList<string>());
            }

            return dict;
        }
    }
}