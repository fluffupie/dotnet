// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
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
        if(_sleeping)
            Console.WriteLine("I'm already sleeping!");
        else
            Console.WriteLine("Goodnight. Zzz");
        _sleeping = true;
    }
}
