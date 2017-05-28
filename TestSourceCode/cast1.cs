using System;
using System.Text;

class Program
{
    static void Main()
    {
        int value = (int)1.5f; // Cast 1.
        Console.WriteLine(value);

        object val = 1;//new StringBuilder();
        if (val is StringBuilder) // Cast 2.
        {
            StringBuilder builder = val as StringBuilder; // Cast 3.
            Console.WriteLine(builder.Length == 0);
        }
    }
}