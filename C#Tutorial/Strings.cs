using System.Text;

namespace Week1;

public static class Strings
{
    public static void Run()
    {
        string s1 = "Hello World";
        Console.WriteLine(s1);

        var name = "Matthew";
        var age = 32;
        var s3 = "Hello " + name + " you are " + age + " years old.";
        Console.WriteLine(s3);

        // String interpolation - use: $
        Console.WriteLine($"Hello {name} you are {age} years old.");

        // Using string concatenation to build up a string at runtime.
        var s5 = string.Empty; // OR = "";
        for(var i = 0; i < 100; i++)
        {
            s5 += name + ' ';
        }
        Console.WriteLine(s5);

        // Using string builder to build up long strings at runtime.
        // Here builder is a StringBuilder.
        var builder = new StringBuilder();
        for(var i = 0; i < 100; i++)
        {
            builder.Append(name);
            builder.Append(' ');
        }

        // Here s6 is a string.
        var s6 = builder.ToString();
        Console.WriteLine(s6);
        Console.WriteLine();

        // Multiline string - use @
        // Here s7 is a string.
        var s7 = @"To whom it may concern,
            This is a multiline string.
            
            New lines are included in this string.
            
            And all white-space within (see spaces to the left).";
        Console.WriteLine(s7);
        Console.WriteLine();

        // Multiline string & interpolation - use $ and @ (any order)
        // Here s8 is a string.
        var s8 = $@"Hi {name},
            You are {age} years old.
            Have a good day.";
        Console.WriteLine(s8);
        Console.WriteLine();

        // Raw string literals - C# 11 feature.
        var s9 =
            """
            This is a raw string literal.

            Content cannot appear to the left of the opening quotes - additionally all space to the left of the quotes
            is compiled out.

            Thus this output is all aligned (unlike a multiline string).
            """;
        Console.WriteLine(s9);
        Console.WriteLine();

        // Raw string literals can be combined with string interpolation. The number of $'s determine the number of
        // braces needed to begin interpolation.
        var s10 =
            $$"""
            My name is {name} and I am {age} years old.
            My name is {{name}} and I am {{age}} years old.

            NOTE: You can also use literal "quotes" within the content provided it is less than the number of "'s used
            to start and end of the raw string literal.
            """;
        Console.WriteLine(s10);
        Console.WriteLine();

        // IsNullOrWhiteSpace and IsNullOrEmpty are useful methods to be aware of.
        Console.Write("Input a message: ");
        var s11 = Console.ReadLine();
        Console.WriteLine();

        if(string.IsNullOrWhiteSpace(s11))
            Console.WriteLine("You entered nothing or only white-space.");
        else
        {
            // The Trim methods are also useful methods to be aware of.
            s11 = s11.Trim();
            Console.WriteLine($"Your message: '{s11}'");
        }
    }
}
