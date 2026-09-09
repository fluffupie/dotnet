namespace Week1;

public static class ConsoleInputAndOutput
{
    public static void Run()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.WriteLine($"Your name is: {name}");
        Console.WriteLine();

        Console.Write("Enter a single character: ");
        var key = Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine($"You entered the following character: '{key.KeyChar}'");
        Console.WriteLine();

        Console.WriteLine("Enter a single character (your input will not be rendered).");
        key = Console.ReadKey(true);
        Console.WriteLine($"You entered the following character: '{key.KeyChar}'");
        Console.WriteLine();
    }
}
