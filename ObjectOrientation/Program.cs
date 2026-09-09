using ObjectOrientation;
using Animals;

IAnimal dog = new Dog("Dazzie");
IAnimal cat = new Cat("Saphira");
IAnimal fish = new Fish("Goldie");

// Local method
void SpeakAndSleep(IAnimal animal)
{
    Console.WriteLine(animal.Name);
    animal.Speak();
    animal.Sleep();
    animal.Sleep();
    Console.WriteLine();
}

SpeakAndSleep(dog);
SpeakAndSleep(cat);
SpeakAndSleep(fish);

var person = new Person("Matthew", "Bolger", dog);

Console.WriteLine(person);

// Show mutating a property.
person.Animal = cat;
Console.WriteLine(person);

person.Animal = fish;
Console.WriteLine(person);
