namespace Task6;
public class Task6Helper
{
    private readonly string path;
    private string? line;
    private string? sign;
    private string? result;


    public Task6Helper(string path)
    {
        this.path = path;
    }

    public void CalculateThread()
    {
        ReadInputFile();
        this.result = $"Data from {Path.GetFileName(path)}: {Program.Calculate(line, sign)}";
    }

    public string? GetResult() => this.result;

    private void ReadInputFile()
    {
        if (string.IsNullOrEmpty(this.path))
        {
            this.line = string.Empty;
            this.sign = string.Empty;
        }

        using var reader = new StreamReader(this.path);
        this.line = reader.ReadLine();
        this.sign = reader.ReadLine();

        PrintInputFile();
    }

    public void PrintInputFile()
    {
        Console.WriteLine($"{Path.GetFileName(this.path)} Input:\n{this.line}\n{this.sign}\n");
    }
}

