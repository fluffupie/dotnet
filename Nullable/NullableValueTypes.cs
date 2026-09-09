// ReSharper disable ConvertNullableToShortForm
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace Week1;

public static class NullableValueTypes
{
    public static void Run()
    {
        int i = 5; // Cannot set a value-type to null.
        Console.WriteLine(i);

        // Can use Nullable<T> type to use null with value-types.
        Nullable<int> ii = null;

        // Can use HasValue bool to know if the variable is null or not
        if (!ii.HasValue)
            Console.WriteLine("ii is null");
        if (ii == null)
            Console.WriteLine("ii is null");

        // Can set the nullable to a value.
        ii = 5;

        if (ii.HasValue)
            Console.WriteLine("ii has a value");
        if (ii != null)
            Console.WriteLine("ii has a value");

        // Can use Value to extract value or just use the variable as is.
        if (ii.HasValue)
            Console.WriteLine($"Value of ii is: {ii.Value}");
        Console.WriteLine($"Value of ii is: {ii}");

        // Short-hand syntax for Nullable<T> is to use ?, e.g., int?
        //int? iii = null;
        // OR
        int? iii = 10;

        Console.WriteLine($"Value of iii is: {iii.Value}");
        Console.WriteLine($"Value of iii is: {iii}");
    }
}
