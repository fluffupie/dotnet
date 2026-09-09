using Animals;

namespace ObjectOrientation;

public class Person
{
    // Readonly properties - getter only.
    // They can be assigned in the constructor but cannot be changed afterward.
    // A property is accessed like a field: person.FirstName
    public string FirstName { get; }
    public string LastName { get; }

    // Mutable property - auto-generated getter and setter.
    public IAnimal Animal { get; set; } // Stores the animal owned by the person.

    // constructor
    public Person(string firstName, string lastName, IAnimal animal)
    {
        FirstName = firstName;
        LastName = lastName;
        Animal = animal;
    }

    public override string ToString() => $"{FirstName} {LastName} owns {Animal.Name} ({Animal.GetType().Name}).";
}
