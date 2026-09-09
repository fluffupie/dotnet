namespace Animals;

public class Cat : AbstractAnimal
{
    public Cat(string name) : base(name)
    { }

    public override void Speak() => Console.WriteLine("Meow.");
}
