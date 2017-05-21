using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Set up data.
        var a1 = new int[100, 100];
        var a2 = new int[100][];
        for (int i = 0; i < 100; i++)
        {
            a2[i] = new int[100];
        }

        // Version 1: access 2D array.
        var s1 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            for (int a = 0; a < 100; a++)
            {
                for (int x = 0; x < 100; x++)
                {
                    int c = a1[a, x];
                }
            }
        }
        s1.Stop();

        // Version 2: access jagged array.
        var s2 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            for (int a = 0; a < 100; a++)
            {
                for (int x = 0; x < 100; x++)
                {
                    int c = a2[a][x];
                }
            }
        }
        s2.Stop();

        // Results.
        Console.WriteLine(s1.Elapsed.TotalMilliseconds);
        Console.WriteLine(s2.Elapsed.TotalMilliseconds);
    }
}