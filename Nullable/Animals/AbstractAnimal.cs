namespace Animals;

public abstract class AbstractAnimal : IAnimal
{
    private bool _sleeping;

    protected AbstractAnimal(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract void Speak();

    public void Sleep()
    {
        Console.WriteLine(_sleeping ? "I'm already sleeping!" : "Goodnight. Zzz");
        _sleeping = true;
    }
}
