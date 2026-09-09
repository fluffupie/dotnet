namespace Animals;

public class Dog : AbstractAnimal
{
    public Dog(string name) : base(name)
    { }

    public override void Speak() => Console.WriteLine("Bark bark!");
}
