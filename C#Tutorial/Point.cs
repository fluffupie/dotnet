using System;

public struct Point
{
    public int XCoord;
    public int YCoord;

    public Point(int x, int y)
    {
        XCoord = x;
        YCoord = y;
    }

    public void Print() => Console.WriteLine("x={0}, y={1}", XCoord, YCoord);
}

public static class PointDemo
{
    private static void Swap(Point p)
    {
        var x = p.XCoord;
        p.XCoord = p.YCoord;
        p.YCoord = x;

        // NOTE: Can also swap via deconstruction.
        //(p.XCoord, p.YCoord) = (p.YCoord, p.XCoord);
    }

    public static void Run()
    {
        int i = 10; // structs: faster because on stack - i.e., the data is present without additional lookup.
        string s = ""; // classes: slower because on heap - i.e., a pointer / reference.

        var p = new Point(1, 2);
        p.Print();
        Swap(p);
        p.Print();
        Console.WriteLine();
    }
}
