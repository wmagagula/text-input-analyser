namespace TextInputAnalyser.Classes;

// ReSharper disable once InconsistentNaming
public static class ConsoleIO
{
    public static string? ReadInput(string? hintText = "")
    {
        Console.Write(hintText);
        return Console.ReadLine();
    }

    public static void WriteOutput(string message)
    {
        Console.WriteLine(message);
    }   
}