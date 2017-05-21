using System;
using System.Collections.Generic;

class Net
{
    public virtual void Act()
    {
    }
}

class Perl : Net
{
    public override void Act()
    {
        Console.WriteLine("Perl.Act");
    }
}

class Python : Net
{
    public override void Act()
    {
        Console.WriteLine("Python.Act");
    }
}

class Program
{
    static void Main()
    {
        // Use base class and derived types in a List.
        List nets = new List();
        nets.Add(new Perl());
        nets.Add(new Python());

        // Call virtual method on each instance.
        foreach (Net net in nets)
        {
            net.Act();
        }
    }
}