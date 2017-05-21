using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Create a string variable and cast it to an object.
        string variable1 = "carrot";
        object variable2 = variable1;

        // Try to cast it to a string.
        string variable3 = variable2 as string;
        if (variable3 != null)
        {
            Console.WriteLine("have string variable");
        }

        // Try to cast it to a StringBuilder.
        StringBuilder variable4 = variable2 as StringBuilder;
        if (variable4 != null)
        {
            Console.WriteLine("have StringBuilder variable");
        }
    }
}