using System;

class Program
{
    static void Main()
    {

        int [,] a = new int [3,4] {
   {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
   {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
   {8, 9, 10, 11}   /*  initializers for row indexed by 2 */
};


        // ... Create 2D array of strings.
        string[,] array = new string[,]
        {
            {"cat", "dog"},
            {"bird", "fish"}
        };
        // ... Print out values.
        Console.WriteLine(array[0, 0]);
        Console.WriteLine(array[0, 1]);
        Console.WriteLine(array[1, 0]);
        Console.WriteLine(array[1, 1]);
    }
}

using System;

class Program
{
    static void Main()
    {
        string[,] words = new string[,]
        {
            {"ONE", "TWO"},
            {"THREE", "FOUR"},
            {"FIVE", "SIX"}
        };

        // Loop based on length.
        // ... Assumes each subarray is two elements long.
        for (int i = 0; i < words.Length / 2; i++)
        {
            string s1 = words[i, 0];
            string s2 = words[i, 1];
            Console.WriteLine("{0}, {1}", s1, s2);
        }
    }
}





using System;

class Program
{
    static void PrintFirstElement(bool[,] values)
    {
        // Display value of first element in first row.
        Console.WriteLine(values[0, 0]);
    }

    static void Main()
    {
        // Any array size of the right element type can be used.
        bool[,] values = new bool[100, 100];
        values[0, 0] = true;
        PrintFirstElement(values);
    }
}