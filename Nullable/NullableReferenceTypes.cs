using ObjectOrientation;
using Animals;

namespace Week1;

public static class NullableReferenceTypes
{
    public static void Run()
    {
        IAnimal dog = new Dog("Dazzie");
        Person person = new Person("Matthew", "Bolger", dog);

        Console.WriteLine(person);

        // Warning as Nullable enabled and Dog will not allow null, need to use Dog? to allow null explicitly.
        //Dog d1 = null;
        Dog? d1 = null;
        d1 = new Dog("Alfie");
        Console.WriteLine(d1.Name);

        // Likewise for strings - now string is considered not nullable, and string? is nullable.
        string s = "Hello";
        //string s = null;
        //string? s = null;
        Console.WriteLine(s);

        // Following from above the Dog constructor that takes in a string should not be passed null as the type is not
        // declared with ?.
        //d1 = new Dog(null);
    }
}
