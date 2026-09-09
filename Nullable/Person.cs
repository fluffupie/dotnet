using Animals;

namespace ObjectOrientation;

public class Person
{
    // Readonly properties - getter only.
    public string FirstName { get; }
    public string LastName { get; }

    // Mutable property - auto-generated getter and setter.
    public IAnimal Animal { get; set; }

    public Person(string firstName, string lastName, IAnimal animal)
    {
        FirstName = firstName;
        LastName = lastName;
        Animal = animal;
    }

    public override string ToString() => $"{FirstName} {LastName} owns {Animal.Name} ({Animal.GetType().Name}).";
}
