// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
namespace Animals;

public abstract class AbstractAnimal : IAnimal
{
    private bool _sleeping; // underscore is a naming convention for a private field

    // Readonly property - implementing INameable.
    public string Name { get; }

    protected AbstractAnimal(string name)
    {
        Name = name;
    }

    // Implementing ISpeakable - abstract thus child must implement.
    public abstract void Speak();

    // Implementing ISleepable
    public void Sleep()
    {
        if (_sleeping)
            Console.WriteLine("I'm already sleeping!");
        else
            Console.WriteLine("Goodnight. Zzz");
        _sleeping = true;
    }
}
