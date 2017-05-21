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