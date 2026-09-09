namespace Animals;

public class Fish : IAnimal
{
    private bool _sleeping;

    public Fish(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Speak() => Console.WriteLine("<wiggle-wiggle>");

    public void Sleep()
    {
        Console.WriteLine(_sleeping ? "I'm already sleeping!" : "Goodnight. Zzz");
        _sleeping = true;
    }
}
