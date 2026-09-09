// File scoped namespace - C# 10 feature.
namespace Animals;

public class Dog
{
    public void Speak()
    {
        Console.WriteLine("Bark bark.");
    }

    public void Play() => Console.WriteLine("Ball?");
}