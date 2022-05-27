using System.Diagnostics;
using System.Text;

namespace Task6;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var file1Path = $@"{AppDomain.CurrentDomain.BaseDirectory}\InputFiles\file1.txt";
        var file2Path = $@"{AppDomain.CurrentDomain.BaseDirectory}\InputFiles\file2.txt";

        while (true)
        {
            Console.WriteLine("Read data:\n" +
                "1. Asynchronion method\n" +
                "2. Multi-thread method\n" +
                "0. Exit");

            Console.WriteLine("Method: ");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                await SolveAsync(file1Path, file2Path);
            }

            if (choice == "2")
            {
                Solve(file1Path, file2Path);
            }

            if (choice == "0") return;
        }
    }

    private static void Solve(string path1, string path2)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        ThreadHelper threadHelper1 = new ThreadHelper(path1);
        ThreadHelper threadHelper2 = new ThreadHelper(path2);

        Thread thread1 = new Thread(new ThreadStart(threadHelper1.CalculateThread));
        Thread thread2 = new Thread(new ThreadStart(threadHelper2.CalculateThread));
        
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        stopwatch.Stop();

        Console.WriteLine("Output:\n" +
            "Multi-thread method\n" +
            $"Time: {stopwatch.Elapsed.TotalSeconds}\n" +
            $"{threadHelper1.GetResult()}\n" +
            $"{threadHelper2.GetResult()}");
    }
    
    private static async Task SolveAsync(string path1, string path2)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        string? str1, sign1, str2, sign2;

        (str1, sign1) = await ReadInputFileAsync(path1);
        (str2, sign2) = await ReadInputFileAsync(path2);

        var result1 = await Task.Run(() => Calculate(str1, sign1));
        var result2 = await Task.Run(() => Calculate(str2, sign2));

        Console.WriteLine($"{Path.GetFileName(path1)} Input:\n{str1}\n{sign1}");
        Console.WriteLine($"{Path.GetFileName(path2)} Input:\n{str2}\n{sign2}");

        stopwatch.Stop();

        Console.WriteLine("Output:\n" +
            "Asynchronion method\n" +
            $"Time: {stopwatch.Elapsed.TotalSeconds}\n" +
            $"Data from {Path.GetFileName(path1)}: {result1}\n" +
            $"Data from {Path.GetFileName(path2)}: {result2}");
    }

    public static string Calculate(string? line, string? sign)
    {
        if (string.IsNullOrEmpty(line) || string.IsNullOrEmpty(sign))
        {
            return string.Empty;
        }

        var numbers = line.Trim().Split(',');
        if (numbers.Length <= 1)
        {
            return line;
        }

        var resultString = new StringBuilder();
        var result = Convert.ToDouble(numbers[0]);
        resultString.Append(result);

        switch (sign)
        {
            case "+":
                for (int i = 1; i < numbers.Length; i++)
                {
                    var num = Convert.ToDouble(numbers[i]);
                    result += num;

                    if (num < 0)
                    {
                        resultString.Append($"+({num})");
                    }
                    else
                    {
                        resultString.Append($"+{num}");
                    }
                }
                break;
            case "-":
                for (int i = 1; i < numbers.Length; i++)
                {
                    var num = Convert.ToDouble(numbers[i]);
                    result -= num;

                    if (num < 0)
                    {
                        resultString.Append($"-({num})");
                    }
                    else
                    {
                        resultString.Append($"-{num}");
                    }
                }
                break;
            case "/":
                for (int i = 1; i < numbers.Length; i++)
                {
                    var num = Convert.ToDouble(numbers[i]);
                    if (num == 0)
                    {
                        throw new DivideByZeroException(nameof(line));
                    }

                    result /= num;

                    if (num < 0)
                    {
                        resultString.Append($"/({num})");
                    }
                    else
                    {
                        resultString.Append($"/{num}");
                    }
                }
                break;
            case "*":
                for (int i = 1; i < numbers.Length; i++)
                {
                    var num = Convert.ToDouble(numbers[i]);
                    result *= num;

                    if (num < 0)
                    {
                        resultString.Append($"*({num})");
                    }
                    else
                    {
                        resultString.Append($"*{num}");
                    }
                }
                break;
        }

        return resultString.Append($" = {Math.Round(result, 7)}").ToString();
    }

    private static async Task<(string?, string?)> ReadInputFileAsync(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return (string.Empty, string.Empty);
        }

        using var reader = new StreamReader(path);
        var line = await reader.ReadLineAsync();
        var sign = await reader.ReadLineAsync();

        return (line, sign);
    }
}