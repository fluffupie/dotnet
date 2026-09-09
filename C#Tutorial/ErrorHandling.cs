// ReSharper disable AssignNullToNotNullAttribute
namespace Week1;

public static class ErrorHandling
{
    public static void Run()
    {
        try
        {
            while(true)
            {
                Console.Write("Enter first number: ");
                var first = decimal.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                var second = decimal.Parse(Console.ReadLine());

                Console.WriteLine($"Answer: {first / second}");
                Console.WriteLine();
            }
        }
        catch(DivideByZeroException e)
        //catch(FormatException e)
        //catch(Exception e)
        //catch(Exception)
        //catch(Exception e) when (e is DivideByZeroException or FormatException)
        //catch(Exception e) when (e is DivideByZeroException || e is FormatException)
        //catch
        {
            // This code runs if / when the exception occurs.
            Console.WriteLine("You can't divide by zero.");
        }
        // Finally is optional.
        finally
        {
            // This code always runs.
        }
    }
}
