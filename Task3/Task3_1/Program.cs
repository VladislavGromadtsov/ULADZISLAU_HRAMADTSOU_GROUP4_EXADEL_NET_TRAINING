using System;
using System.Text;
using System.Linq;

namespace Task3_1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<string> lastnames = new List<string> { "Johnson", "Williams", "Brown", "Jones" };
            Queue<string> inputQueue = new Queue<string>(lastnames);

            Dictionary<char, LinkedList<string>> dict = FillDictKeys();

            Console.Write("Input: ");
            for (int i = 0; i < lastnames.Count; i++)
            {
                if (i != lastnames.Count - 1)
                {
                    Console.Write($"\"{lastnames[i]}\", ");
                }
                else
                { 
                    Console.Write($"\"{lastnames[i]}\"\n");
                }
            }

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