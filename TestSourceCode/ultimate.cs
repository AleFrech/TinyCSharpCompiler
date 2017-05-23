using System;
using System.Collections;

namespace Shell_Sort
{
    public class SortShell
    {
       static void Main(string[] args)
        {
            int[] arr;
            int n;

            n = arr.Length;
            Console.WriteLine("Original Array Elements :");
            show_array_elements(arr);
            shellSort(arr, n);
            Console.WriteLine("\nSorted Array Elements :");
            show_array_elements(arr);
        }

        static void shellSort(int[] arr, int array_size)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        static void show_array_elements(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");

        }
    }
}


using System;
 namespace Radix_Sort
{
    class Program
    {
        static void Sort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)   
                        arr[i-j] = arr[i];
                    else                             
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length-j, j);
            }
        }
        static void Main(string[] args)
        {
            
			int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6  };
			Console.WriteLine("\nOriginal array : ");
			foreach (var item in arr)
            {
                Console.Write(" " + item);    
            }

            Sort(arr);
			Console.WriteLine("\nSorted array : ");
			foreach (var item in arr)
            {
                Console.Write(" " + item);    
            }
           Console.WriteLine("\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Selection_Sort selection = new Selection_Sort(10);
            selection.Sort();
        }
    }

    class Selection_Sort
    {
        private int[] data;
        private static Random generator = new Random();
        //Create an array of 10 random numbers
           public Selection_Sort(int size)
        {
            data;// = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = generator.Next(20, 90);
            }
        }

        public void Sort()
        {
            Console.Write("\nSorted Array Elements :(Step by Step)\n\n");
			display_array_elements();
			int smallest; 
            for (int i = 0; i < data.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < data.Length; index++)
                {
                    if (data[index] < data[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
                display_array_elements();
		   }
            	
        }

        public void Swap(int first, int second)
        {
            int temporary = data[first];    
            data[first] = data[second];  
            data[second] = temporary;  
        }  

        public void display_array_elements()
        {        
            foreach (var element in data)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n\n");
        }
    }
}

using System;

namespace Heap_sort
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			int[] mykeys = new int[] {2, 5, -4, 11, 0, 18, 22, 67, 51, 6};

			double[] mykeys = new double[] {2.22f, 0.5f, 2.7f, -1.0f, 11.2f};

		    string[] mykeys = new string[] {"Red", "White", "Black", "Green", "Orange"};
              
			Console.WriteLine("\nOriginal Array Elements :");  
			printArray (mykeys);

			heapSort (mykeys);
           
		    Console.WriteLine("\n\nSorted Array Elements :");
			printArray (mykeys);
            Console.WriteLine("\n");
		}

		private static void heapSort (T[] array) 
		{
			int heapSize = array.Length;

			buildMaxHeap (array);

			for (int i = heapSize-1; i >= 1; i--)
			{
				swap (array, i, 0);
				heapSize--;
				sink (array, heapSize, 0);
			}
		}

		private static void buildMaxHeap (T[] array)
		{
			int heapSize = array.Length;

			for (int i = (heapSize/2) - 1; i >= 0; i--)
			{
				sink (array, heapSize, i);
			}
		}

		private static void sink (T[] array, int heapSize, int toSinkPos) 
		{
			if (getLeftKidPos (toSinkPos) >= heapSize)
			{
				// No left kid => no kid at all
				return;
			}


			int largestKidPos;
			bool leftIsLargest;

			if (getRightKidPos (toSinkPos) >= heapSize || array [getRightKidPos (toSinkPos)].CompareTo (array [getLeftKidPos (toSinkPos)]) < 0)
			{
				largestKidPos = getLeftKidPos (toSinkPos);
				leftIsLargest = true;
			} else
			{
				largestKidPos = getRightKidPos (toSinkPos);
				leftIsLargest = false;
			}
			


			if (array [largestKidPos].CompareTo (array [toSinkPos]) > 0)
			{
				swap (array, toSinkPos, largestKidPos);

				if (leftIsLargest)
				{
					sink (array, heapSize, getLeftKidPos (toSinkPos));

				} else
				{
					sink (array, heapSize, getRightKidPos (toSinkPos));
				}
			}

		}

		private static void swap (T[] array, int pos0, int pos1)
		{
			T tmpVal = array [pos0];
			array [pos0] = array [pos1];
			array [pos1] = tmpVal;
		}

		private static int getLeftKidPos (int parentPos)
		{
			return (2 * (parentPos + 1)) - 1;
		}

		private static int getRightKidPos (int parentPos)
		{
			return 2 * (parentPos + 1);
		}

		private static void printArray (T[] array)
		{
							
			foreach (T t in array)
			{
			    Console.Write(' '+t.ToString()+' ');
			}

		}
	}

}


using System;
using System.Linq;
public class Counting_sort  
{  
 public static void Main()  
    {  
int[] array = new int[10]
{
    2, 5, -4, 11, 0, 8, 22, 67, 51, 6
};
 
    Console.WriteLine("\n"+"Original array :");
           foreach (int aa in array)                       
           Console.Write(aa + " "); 

    int[] sortedArray = new int[array.Length];
 
    // find smallest and largest value
    int minVal = array[0];
    int maxVal = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < minVal) minVal = array[i];
        else if (array[i] > maxVal) maxVal = array[i];
    }
 
    // init array of frequencies
    int[] counts = new int[maxVal - minVal + 1];
 
    // init the frequencies
    for (int i = 0; i < array.Length; i++)
    {
        counts[array[i] - minVal]++;
    }
 
    // recalculate
    counts[0]--;
    for (int i = 1; i < counts.Length; i++)
    {
        counts[i] = counts[i] + counts[i - 1];
    }
 
    // Sort the array
    for (int i = array.Length - 1; i >= 0; i--)
    {
        sortedArray[counts[array[i] - minVal]--] = array[i];
    }
 
  Console.WriteLine("\n"+"Sorted array :");
           foreach (int aa in sortedArray)                       
           Console.Write(aa + " "); 
  Console.Write("\n");            
                   
}
}
/*
 * C# Program to Establish Client Server Relationship
 */
//SERVER PROGRAM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace Server336
{
    class Program
    {
        static void Main(string[] args)
        {
                hola[] b = new hola[100];
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(b[i]));
                }
                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.Getholas("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                s.Close();
                myList.Stop();

            Console.ReadLine().forEach();
        }
    }
}
 
//CLIENT PROGRAM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
 
namespace Client336
{
    class Program
    {
        static void Main(string[] args)
        {

                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("10.18.227.162", 8001);                
                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");
                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                hola[] ba = asen.Getholas(str);
                Console.WriteLine("Transmitting.....");
                stm.Write(ba, 0, ba.Length);
                hola[] bb; //= new hola[100];
                int k = stm.Read(bb, 0, 100);
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));
                tcpclnt.Close();
                Console.Read();

        }
    }
}

using System;
using System.Text;

class Program
{
    static void Main()
    {
        int value = (int)1.5f; // Cast 1.
        Console.WriteLine(value);

        object val = new StringBuilder();
        if (val is StringBuilder) // Cast 2.
        {
            StringBuilder builder = val as StringBuilder; // Cast 3.
            Console.WriteLine(builder.Length == 0);
        }
    }
}

using System;
namespace InheritanceApplication
{
   class Shape 
   {
       void setWidth(int w)
      {
         width = w;
      }
      public void setHeight(int h)
      {
         height = h;
      }
      protected int width;
      protected int height;
   }

   // Derived class
   class Rectangle: Shape
   {
      int getArea()
      { 
         return (width * height); 
      }
   }
   
   class RectangleTester
   {
      static void Main(string[] args)
      {
         Rectangle Rect = new Rectangle();

         Rect.setWidth(5);
         Rect.setHeight(7);

         // Print the area of the object.
         Console.WriteLine("Total area: {0}",  Rect.getArea());
         Console.ReadKey();
      }
   }
}

using System;
namespace RectangleApplication
{
   class Rectangle
   {
      //member variables
      protected double length;
      protected double width;
      public Rectangle(double l, double w)
      {
         length = l;
         width = w;
      }
      
      public double GetArea()
      {
         return length * width;
      }
      
      public void Display()
      {
         Console.WriteLine("Length: {0}", length);
         Console.WriteLine("Width: {0}", width);
         Console.WriteLine("Area: {0}", GetArea());
      }
   }//end class Rectangle  
   
   class Tabletop : Rectangle
   {
      private double cost;
      public Tabletop(double l, double w) : base(l, w)
      { }
      public double GetCost()
      {
         double cost;
         cost = GetArea() * 70;
         return cost;
      }
      public void Display()
      {
         base.Display();
         Console.WriteLine("Cost: {0}", GetCost());
      }
   }
   class ExecuteRectangle
   {
      static void Main(string[] args)
      {
         Tabletop t = new Tabletop(4.5f, 7.5f);
         t.Display();
         Console.ReadLine();
      }
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
        Triangle t1 = new Triangle();  
        Triangle t2 =new Triangle();  
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

    public  void print()

    {

        base.print();

        Console.WriteLine("I'm a Child Class.");

    }

    public static void Main()

    {

        Child child = new Child();

        child.print();

        ((Parent)child).print();

    }

}
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


public class Animal
{
    public virtual String talk() { return "Hi"; }
    public string sing() { return "lalala"; }
}

public class Cat : Animal
{
    public override String talk() { return "Meow!"; }
}

public class Dog : Animal
{
    public override String  talk() { return "Woof!"; }
    public string sing() { return "woofa woofa woooof"; }
}

public class CSharpExampleTestBecauseYouAskedForIt
{
    public CSharpExampleTestBecauseYouAskedForIt()
    {
        write(new Cat());
        write(new Dog());
    }

    public void write(Animal a) {
        System.Diagnostics.Debug.WriteLine(a.talk());
    }

}