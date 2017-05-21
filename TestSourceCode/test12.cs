using System;

public class Parent

{

    string parentString;

    public Parent()

    {

        Console.WriteLine("Parent Constructor.");

    }

    public Parent(string myString)

    {

        parentString = myString;

        Console.WriteLine(parentString);

    }

    public void print()

    {

        Console.WriteLine("I'm a Parent Class.");

    }

}




public class Child : Parent

{

    public Child() : base("From Derived")

    {

        Console.WriteLine("Child Constructor.");

    }

    public void print()

    {

        base.print();

        Console.WriteLine("I'm a Child Class.");

    }

    public static void Main()

    {

        Child child = new Child();
        
        child.print();

        ((Parent)child).print=7;

    }

}


//Base class or Parent class.  
class Shape  
{  
    public double Width;  
    public double Height;  
    public void ShowDim()  
    {  
        Console.WriteLine("Width and height are " +  
        Width + " and " + Height);  
    }  
}  
// Triangle is derived from Shape.  
//Drived class or Child class.  
class Triangle : Shape  
{  
    public string Style; // style of triangle  
    // Return area of triangle.  
    public double Area()  
    {  
        return Width * Height / 2;  
    }  
    // Display a triangle's style.  
    public void ShowStyle()  
    {  
        Console.WriteLine("Triangle is " + Style);  
    }  
}  
//Driver class which runs the program.  
class Driver  
{  
    static void Main()  
    {  
        ++ (new m()).y;
        Triangle t1 = new Triangle();  
        Triangle t2 = new Triangle();  
        t1.Width =4.0f;  
        t1.Height =4.0f;  
        t1.Style ="isosceles";  
        t2.Width =8.0f;  
        t2.Height =12.0f;  
        t2.Style ="right";  
        Console.WriteLine("Info for t1: ");  
        t1.ShowStyle();  
        t1.ShowDim();  
        Console.WriteLine("Area is " + t1.Area());  
        Console.WriteLine();  
        Console.WriteLine("Info for t2: ");  
        t2.ShowStyle();  
        t2.ShowDim();  
        Console.WriteLine("Area is " + t2.Area());  
    }  
}