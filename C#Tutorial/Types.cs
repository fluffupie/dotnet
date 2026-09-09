namespace Week1;

public static class Types
{
    // Constants - compile-time constants (const are implicitly static).
    // Constants can be a character, number, boolean, string, or a null reference.
    public const int DaysInWeek = 7;

    // Readonly - run-time constants (readonly variables can be static or non-static).
    public static readonly int TodaysDate = DateTime.Today.Day;
    public static readonly string Message =
        Random.Shared.Next() == 1 ? "You are the jackpot winner!" : "Better luck next time.";

    public static void Run()
    {
        // Value type (struct): int, bool, char, float, double
        // Integers.
        int i = 1;
        short s = 1;
        long l = 1;

        // Same as above.
        Int32 ii = 1;
        Int16 ss = 1;
        Int64 ll = 1;

        // Unsigned integers.
        byte @byte = 1;
        uint u = 1;

        UInt32 uu = 1;

        // Truth.
        bool b = true;

        Boolean bb = false;

        // Floats.
        float f = 10.5f;
        double d = 10.5;

        Single ff = 10.5f;
        Double dd = 10.5;

        // Decimals - precise maths with decimal places.
        decimal dec1 = 1;
        Decimal dec2 = 1.5m;

        // Character.
        char c = 'H';
        Char cc = 'H';

        // Reference type (class).
        object o1 = new object();
        Object o2 = new Object();

        // Target-typed new - C# 9 feature.
        object o3 = new();

        string str1 = "Hello";
        String str2 = "Hello";

        // Arrays.
        int[] ints1 = [1, 2, 4, 10];
        int[] ints2 = [1, 2, 4, 10];
        int[] ints3 = [1, 2, 4, 10];

        string[] strings1 = ["Hello", "World"];
        char[] chars1 = ['H', 'e', 'l', 'l', 'o'];

        var charsWithVar = new[] { 'H', 'e', 'l', 'l', 'o' };
    }
}
