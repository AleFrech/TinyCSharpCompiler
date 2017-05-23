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

            Console.ReadLine();
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














using Compiler.Lexer;
using System;

namespace Compiler.Syntactic
{
    public class Parser
    {
        private ITokenable Lexer;
        private Token CurrentToken;

        public Parser(ITokenable lexer )
        {
            this.Lexer = lexer;
            this.CurrentToken = Lexer.GetNextToken();
        }

        public string GetErrorMessage(string expected, Token token)
        {
            return "Expected {expected} at row: {token.Row} and column: {token.Column} but found {token.Lexema}";
        }
        public void Run()
        {
            Code();
            if(this.CurrentToken.Type != TokenType.Eof)
            {
              //  //throw new ParserException(GetErrorMessage("end of file",CurrentToken));
            }
        }

     
        private void Code()
        {
           NamespacesList();
        }

        private void NamespacesList()
        {
            if(this.CurrentToken.Type.IsNamespaceProduction())
            {
                Namespace();
                NamespacesList();
            }
            else
            {

            }
        }

        private void Namespace()
        {
            UsingDirectives();
            NamespaceDeclarations();
        }

        private void UsingDirectives()
        {
            if (CurrentToken.Type.IsUsingStatement())
            {
                UsingDirective();
                UsingDirectives();
            }
            else
            {

            }
        }

        private void UsingDirective()
        {
            if (!CurrentToken.Type.IsUsingStatement())
            {
                //throw new ParserException(GetErrorMessage("using",CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            TypeName();
            if (!CurrentToken.Type.IsEndOfStatement())
            {
                //throw new ParserException(GetErrorMessage(";", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void TypeName()
        {
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id",CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            TypeNamePrime();
        }
        private void TypeNamePrime()
        {
            if (CurrentToken.Type.IsMemberAccessor())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeName();
            }
            else
            {

            }
        }
        private void NamespaceDeclarations()
        {
            if (CurrentToken.Type.IsNamespaceDeclaration())
            {
                NamespaceDeclaration();
                NamespaceDeclarations();
            }
            else
            {

            }
        }

        private void NamespaceDeclaration()
        {
            if (CurrentToken.Type.IsNamespaceKeyWord())
            {
                NamespaceStatement();
            }
            else
            {
                PrivacyModifier();
                ClassInterfaceOrEnumDeclaration();
            }
        }
        private void NamespaceStatement()
        {
            if (!CurrentToken.Type.IsNamespaceKeyWord())
            {
                //throw new ParserException(GetErrorMessage("namespace", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            TypeName();
            NamespaceBody();
        }

        private void NamespaceBody()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{",CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            Namespace();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
               // //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }
        private void ClassInterfaceOrEnumDeclaration()
        {
            if (CurrentToken.Type.IsClassDeclaration())
            {
                ClassDeclaration();
            }else if (CurrentToken.Type.IsInterfaceKeyWord())
            {
                InterfaceDeclaration();
            }
            else if (CurrentToken.Type.IsEnumKeyWord())
            {
                EnumDeclaration();
            }
            else
            {
               // //throw new ParserException(GetErrorMessage("class, interface or enum",CurrentToken));
            }
        }


        private void ClassDeclaration()
        {
            ClassModifier();
            if (!CurrentToken.Type.IsClassKeyWord())
            {
                //throw new ParserException(GetErrorMessage("class keyword", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            Inheritance();
            ClassBody();
        }

        private void ClassBody()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            ClassMemberDeclarations();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void ClassMemberDeclarations()
        {
            if (CurrentToken.Type.IsPrivacyModifier()
                || CurrentToken.Type.IsFieldMethodPropertyOrConstructor() 
                || CurrentToken.Type.IsType() 
                || CurrentToken.Type.IsMethodModifier()
                || CurrentToken.Type.IsVoid())
            {
                ClassMemberDeclaration();
                ClassMemberDeclarations();
            }
            else
            {

            }
        }

        private void ClassMemberDeclaration()
        {
            PrivacyModifier();
            if (CurrentToken.Type.Equals(TokenType.KeyWordAbstract))
            {
                CurrentToken = Lexer.GetNextToken();
                InterfaceElement();
            }
            else
            {
                FieldMethodPropertyOrConstructor();
            }
        }

        private void FieldMethodPropertyOrConstructor()
        {
            if (CurrentToken.Type.IsStaticKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
                StaticOptions();
            }
            else if (CurrentToken.Type.IsPredefinedType() || CurrentToken.Type.IsEnumKeyWord())
            {
                CustomType();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                FieldMethodOrPropertyDeclaration();
            }
            else if (CurrentToken.Type.IsVoid())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodDeclaration();
            }
            else if (CurrentToken.Type.IsMethodModifier())
            {
                MethodModifiers();
                MethodReturn();
            }
            else if(CurrentToken.Type.IsId())
            {
                TypeName();
                TypeProductionPrime();
                FieldMethodPropertyOrConstructorPrime();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("field, method or constructor", CurrentToken));
            }
        }

        private void FieldMethodPropertyOrConstructorPrime()
        {
            if (CurrentToken.Type.IsOpenParenthesis())
            {
                CurrentToken = Lexer.GetNextToken();
                ParameterList();
                if (!CurrentToken.Type.IsCloseParenthesis())
                {
                    //throw new ParserException(GetErrorMessage(")", CurrentToken));

                }
                CurrentToken = Lexer.GetNextToken();
                ConstructorInitializer();
                Block();
            }
            else if (CurrentToken.Type.IsId())
            {
                CurrentToken = Lexer.GetNextToken();
                FieldMethodOrPropertyDeclaration();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("id or parenthesis", CurrentToken));
            }
        }

        private void ConstructorInitializer()
        {
            if (CurrentToken.Type.IsColonSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                ConstructorInitializerPrime();
            }
            else
            {

            }
        }

        private void ConstructorInitializerPrime()
        {
            if (CurrentToken.Type.Equals(TokenType.KeyWordBase))
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsOpenParenthesis())
                {
                    //throw new ParserException(GetErrorMessage("(", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                ArgumentList();
                if (!CurrentToken.Type.IsCloseParenthesis())
                {
                    //throw new ParserException(GetErrorMessage(")", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
            }
        }

        private void ArgumentList()
        {
            if (CurrentToken.Type.IsExpression())
            {
                Expression();
                ArgumentListPrime();
            }
            else
            {

            }
        }

        private void ArgumentListPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                Expression();
                ArgumentListPrime();
            }
            else
            {

            }
        }

        private void MethodReturn()
        {
            if (CurrentToken.Type.IsType())
            {
                TypeProduction();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodPropertyDeclaration();
            }
            else if (CurrentToken.Type.IsVoid())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodDeclaration();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("type or void", CurrentToken));
            }
        }

        private void MethodPropertyDeclaration()
        {
            if (CurrentToken.Type.IsOpenParenthesis())
            {
                MethodDeclaration();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("(", CurrentToken));
            }
        }

        private void MethodModifiers()
        {
            if (CurrentToken.Type.IsMethodModifier())
            {
                CurrentToken = Lexer.GetNextToken();
            }
        }

        private void StaticOptions()
        {
            if (CurrentToken.Type.IsPredefinedType() || CurrentToken.Type.IsEnumKeyWord())
            {
                CustomType();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id",CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                FieldMethodOrPropertyDeclaration();
            }
            else if (CurrentToken.Type.IsVoid())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodDeclaration();
            }
            else if (CurrentToken.Type.IsId())
            {
                TypeName();
                TypeProductionPrime();
                StaticOptionsPrime();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("primitive type, enum, void or id", CurrentToken));
            }
        }

        private void StaticOptionsPrime()
        {
            if (CurrentToken.Type.IsOpenParenthesis())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsCloseParenthesis())
                {
                    //throw new ParserException(GetErrorMessage(")", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                Block();
            }
           else if (CurrentToken.Type.IsId())
            {
                CurrentToken = Lexer.GetNextToken();
                FieldMethodOrPropertyDeclaration();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("( or id", CurrentToken));
            }
        }

        private void Block()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            StatementList();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void StatementList()
        {
            if (CurrentToken.Type.IsStatement())
            {
                Statement();
                StatementList();
            }
            else
            {

            }
        }

        private void MethodDeclaration()
        {
            MethodHeader();
            MethodBody();
        }

        private void MethodBody()
        {
            Block();
        }

        private void FieldMethodOrPropertyDeclaration()
        {
            if (CurrentToken.Type.IsAssignationOperator() || CurrentToken.Type.IsCommaSymbol() || CurrentToken.Type.IsEndOfStatement())
            {
                FieldDeclarations();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
            }
            else if (CurrentToken.Type.IsOpenParenthesis())
            {
                MethodDeclaration();
            }
        }

        private void FieldDeclarations()
        {
            FieldAssignation();
            FieldDeclarationsPrime();
        }

        private void FieldDeclarationsPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                FieldDeclarations();
            }
            else
            {

            }
        }

        private void FieldAssignation()
        {
            if (CurrentToken.Type.IsAssignationOperator())
            {
                CurrentToken = Lexer.GetNextToken();
                VariableInitializer();
            }
            else
            {

            }
        }

        private void VariableInitializer()
        {
            if (CurrentToken.Type.IsExpression())
            {
                Expression();
            }
            else if (CurrentToken.Type.IsOpenCurlyBraces())
            {
                ArrayInitializer();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("expression or (", CurrentToken));
            }
        }

        private void ArrayInitializer()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            OptionalVariableInitializerList();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void OptionalVariableInitializerList()
        {
            if (CurrentToken.Type.IsOpenCurlyBraces() || CurrentToken.Type.IsExpression())
            {
                VariableInitializerList();
            }
            else
            {

            }
        }

        private void VariableInitializerList()
        {
            VariableInitializer();
            VariableInitializerListPrime();
        }

        private void VariableInitializerListPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                VariableInitializer();
                VariableInitializerListPrime();
            }
            else
            {

            }
        }

        private void CustomType()
        {
            if (CurrentToken.Type.IsPredefinedType())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeProductionPrime();
            }
            else if (CurrentToken.Type.IsEnumKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeProductionPrime();
            }
        }

        private void Inheritance()
        {
            if (CurrentToken.Type.IsColonSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeName();
                Base();
            }
            else
            {

            }
        }

        private void Base()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeName();
                Base();
            }
            else
            {

            }
        }

        private void ClassModifier()
        {
            if (CurrentToken.Type.IsClassModifier())
            {
                CurrentToken = Lexer.GetNextToken();
            }
            else
            {

            }
        }

        private void PrivacyModifier()
        {
            if (CurrentToken.Type.IsPrivacyModifier())
            {
                CurrentToken = Lexer.GetNextToken();
            }
            else
            {

            }
        }
        
 
        private void InterfaceDeclaration()
        {
            if (!CurrentToken.Type.IsInterfaceKeyWord())
            {
                //throw new ParserException(GetErrorMessage("Interface keyword", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            Inheritance();
            InterfaceBody();
        }   
        private void InterfaceBody()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            InterfaceMembersDeclarations();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void InterfaceMembersDeclarations()
        {
            if (CurrentToken.Type.IsVoid() || CurrentToken.Type.IsType())
            {
                InterfaceElement();
                InterfaceMembersDeclarations();
            }
            else
            {

            }
        }

        private void InterfaceElement()
        {
            if (CurrentToken.Type.IsType())
            {
                TypeProduction();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodProperty();
            }
            else if(CurrentToken.Type.IsVoid())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsId())
                {
                    //throw new ParserException(GetErrorMessage("id", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                MethodProperty();
            }
      
        }
        private void TypeProductionForArrayOrObject()
        {
            if (CurrentToken.Type.IsId())
            {
                TypeName();
            }
            else if (CurrentToken.Type.IsPredefinedType())
            {
                CurrentToken = Lexer.GetNextToken();
            }
            else if (CurrentToken.Type.IsEnumKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
            }
            else
            {
                //throw new ParserException(GetErrorMessage("id, type or enum", CurrentToken));
            }
        }
        private void TypeProduction()
        {
            if (CurrentToken.Type.IsId())
            {
                TypeName();
                TypeProductionPrime();
            }
            else if (CurrentToken.Type.IsPredefinedType())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeProductionPrime();
            }
            else if (CurrentToken.Type.IsEnumKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
                TypeProductionPrime();
            }
        }

        private void TypeProductionPrime()
        {
            if (CurrentToken.Type.IsOpenBrackets())
            {
                RankSpecifiers();
                TypeProductionPrime();
            }
            else
            {

            }
        }

        private void RankSpecifiers()
        {
            if (CurrentToken.Type.IsOpenBrackets())
            {
                RankSpecifier();
                RankSpecifiersPrime();
            }
        }

        private void RankSpecifiersPrime()
        {
            if (CurrentToken.Type.IsOpenBrackets())
            {
                RankSpecifier();
                RankSpecifiersPrime();
            }
            else
            {

            }
        }

        private void OptionalDimSeparators()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                DimSeparators();
            }
            else
            {

            }
        }

        private void DimSeparators()
        {
            if (!CurrentToken.Type.IsCommaSymbol())
            {
                //throw new ParserException(GetErrorMessage(",", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            DimSeparatorsPrime();

        }

        private void DimSeparatorsPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                DimSeparatorsPrime();
            }
            else
            {

            }
        }

        private void RankSpecifier()
        {
            if (!CurrentToken.Type.IsOpenBrackets())
            {
                //throw new ParserException(GetErrorMessage("[", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            OptionalDimSeparators();
            if (!CurrentToken.Type.IsCloseBrackets())
            {
                //throw new ParserException(GetErrorMessage("]", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void MethodProperty()
        {
            if (CurrentToken.Type.IsOpenParenthesis())
            {
                MethodHeader();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
            }
            else 
            {
                //throw new ParserException(GetErrorMessage("(", CurrentToken));
            }
        }

        private void PropertyDeclaration()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            PropertyAccessors();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void PropertyAccessors()
        {
            PropertyAccessorsPrivacyModifiers();
            PropertyAccessorsBody();
        }

        private void PropertyAccessorsBody()
        {
            if (CurrentToken.Type.IsGetKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                SetAccessor();

            }
            else if (CurrentToken.Type.IsSetKeyWord())
            {
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
                GetAccessor();
            }
        }

        private void GetAccessor()
        {
            if (CurrentToken.Type.IsPropertyPrivacyModifier() || CurrentToken.Type.IsGetKeyWord())
            {
                PropertyAccessorsPrivacyModifiers();
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
            }
            else
            {

            }
        }

        private void SetAccessor()
        {
            if (CurrentToken.Type.IsPropertyPrivacyModifier() || CurrentToken.Type.IsSetKeyWord())
            {
                PropertyAccessorsPrivacyModifiers();
                CurrentToken = Lexer.GetNextToken();
                if (!CurrentToken.Type.IsEndOfStatement())
                {
                    //throw new ParserException(GetErrorMessage(";", CurrentToken));
                }
                CurrentToken = Lexer.GetNextToken();
            }
            else
            {

            }
        }

        private void PropertyAccessorsPrivacyModifiers()
        {
            if (CurrentToken.Type.IsPropertyPrivacyModifier())
            {
                CurrentToken = Lexer.GetNextToken();
            }
        }

        private void MethodHeader()
        {
            if (!CurrentToken.Type.IsOpenParenthesis())
            {
                //throw new ParserException(GetErrorMessage("(", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            ParameterList();
            if (!CurrentToken.Type.IsCloseParenthesis())
            {
                //throw new ParserException(GetErrorMessage(")", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void ParameterList()
        {
            if (CurrentToken.Type.IsType())
            {
                Parameter();
                ParameterListPrime();
            }
            else
            {

            }
        }

        private void ParameterListPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                Parameter();
                ParameterListPrime();
            }
            else
            {

            }
        }

        private void Parameter()
        {
            TypeProduction();
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }
        
     
        private void EnumDeclaration()
        {
            if (!CurrentToken.Type.IsEnumKeyWord())
            {
                //throw new ParserException(GetErrorMessage("enum keyword", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            EnumBody();
        }

        private void EnumBody()
        {
            if (!CurrentToken.Type.IsOpenCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("{", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            EnumMemberDeclarations();
            if (!CurrentToken.Type.IsCloseCurlyBraces())
            {
                //throw new ParserException(GetErrorMessage("}", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
        }

        private void EnumMemberDeclarations()
        {
            if (CurrentToken.Type.IsId())
            {
                EnumElement();
                EnumMemberDeclarationsPrime();
            }
            else
            {

            }
        }

        private void EnumMemberDeclarationsPrime()
        {
            if (CurrentToken.Type.IsCommaSymbol())
            {
                CurrentToken = Lexer.GetNextToken();
                EnumElement();
                EnumMemberDeclarationsPrime();
            }
            else
            {

            }
        }

        private void EnumElement()
        {
            if (!CurrentToken.Type.IsId())
            {
                //throw new ParserException(GetErrorMessage("id", CurrentToken));
            }
            CurrentToken = Lexer.GetNextToken();
            EnumElementBody();
        }

        private void EnumElementBody()
        {
            if (CurrentToken.Type.IsAssignationOperator())
            {
                CurrentToken = Lexer.GetNextToken();
                Expression();
            }
            else
            {

            }
        }

        


        
    }
}





