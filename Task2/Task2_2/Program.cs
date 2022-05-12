using System;
using System.Text;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string InputPath1 = @"..\..\..\InputFiles\InputFile1.txt";
            string InputPath2 = @"..\..\..\InputFiles\InputFile2.txt";
            string InputPath3 = @"..\..\..\InputFiles\InputFile3.txt";

            string OutputPath = @"..\..\..\OutputFiles\ResultFile.txt";

            string sentence1, sentence2, sentence3;

            sentence1 = ReadInputFile(InputPath1);
            Console.WriteLine("File 1 Input: \"" + sentence1 + "\"");

            sentence2 = ReadInputFile(InputPath2);
            Console.WriteLine("File 2 Input: \"" + sentence2 + "\"");

            sentence3 = ReadInputFile(InputPath3);
            Console.WriteLine("File 3 Input: \"" + sentence3 + "\"");

            sentence1 = GetReverse(sentence1);
            sentence2 = GetReverse(sentence2);
            sentence3 = GetReverse(sentence3);

            WriteToResultFile(OutputPath, sentence1, sentence2, sentence3);

            Console.WriteLine("\nResult file:\n" + ReadResultFile(OutputPath));
        }

        private static string GetReverse(string sentence)
        {
            string[] words = sentence.Split(' ');
            Stack<string> stack = new Stack<string>();

            foreach (string word in words)
            {
                stack.Push(CheckWord(word));
            }

            StringBuilder reverse = new StringBuilder();
            while (stack.Count > 0)
            {
                if (stack.Count != 1)
                {
                    reverse.Append(stack.Pop() + " ");
                }
                else
                {
                    reverse.Append(stack.Pop());
                }
            }

            return reverse.ToString();
        }

        private static string CheckWord(string word)
        {
            StringBuilder sbUpper = new StringBuilder();
            StringBuilder sbLowwer = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] >= 65 && word[i] <= 90)
                {
                    sbUpper.Append(word[i]);
                }

                if (word[i] >= 97 && word[i] <= 122)
                {
                    sbLowwer.Append(word[i]);
                }
            }

            return sbUpper.Append(sbLowwer.ToString()).ToString();
        }

        private static string ReadInputFile(string inputPath)
        {
            using (StreamReader reader = new StreamReader(inputPath))
            {
                var sentence = reader.ReadLine();

                return sentence is null ? "" : sentence;
            }
        }

        private static void WriteToResultFile(string resultPath, params string[] sentences)
        {
            using (StreamWriter writer = new StreamWriter(resultPath, false))
            {
                Array.ForEach(sentences.OrderBy(x => x.Length).ToArray(), sentence => writer.WriteLine(sentence));
            }
        }
        private static string ReadResultFile(string inputPath)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputPath))
            {
                while (!reader.EndOfStream)
                {
                    string? s = reader.ReadLine();
                    
                    if (s != null)
                    {
                        result.AppendLine("\"" + s + "\"");
                    }
                }
            }

            return result.ToString();
        }
    }
}