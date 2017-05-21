public abstract class Employee 
{ 
    protected string name;

    public Employee(string name)  // constructor
    { 
        this.name = name;
    }

    public abstract void Show();  // abstract show method
}

public class Manager: Employee
{ 
    public Manager(string name) : base(name) {}  // constructor 

    public override void Show()  //override the abstract show method
    {
        System.Console.WriteLine("Name : " + name);
    }
}

class TestEmployeeAndManager
{ 
    static void Main()
    { 
        // Create an instance of Manager and assign it to a Manager reference:
        Manager m1 = new Manager("H. Ackerman");
        m1.Show();

        // Create an instance of Manager and assign it to an Employee reference:
        Employee ee1 = new Manager("M. Knott");
        ee1.Show();  //call the show method of the Manager class
    } 
}