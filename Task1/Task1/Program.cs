using System;

namespace Task1 // Note: actual namespace depends on the project name.
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var text = "Number: ";

            for (var a = 4; a < 10; a++)
            {
                Console.WriteLine(text + a);
                Console.ReadKey();
            }
        }
    }
}