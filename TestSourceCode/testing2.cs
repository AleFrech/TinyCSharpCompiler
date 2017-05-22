// Using directives
using System;
using System.Linq;

interface Test
{
    
}

enum EnumTest
{
    
}

// Nested namespaces
namespace X
{
    namespace A
    {
        namespace B
        {
            namespace C
            {
                using System.Console;
            }
        }
    }

    namespace D
    {
        class SomeClass
        {
            private int x;
            private bool[,] y;

            protected static int counter;

            protected SomeClass()
            {
                
            }

            public static void main()
            {
                
            }

            private abstract int test(float x, bool what);


            private static int Z = 1;

            SomeClass(int a, int b)
            {
                
            }
        }

        private class AnotherClass
        {
            
        }
    }
}

namespace Y
{
    enum Test
    {
        A, B, C, D
    }

    private enum Test2
    {
        A = 1, B, C = 4
    }
}

namespace Z
{
    public enum Test
    {
        
    }

    interface ITest : IInterface, ISomething, IDontKnow
    {
        string doSomething(string message);
        void sayHi();
        bool truthy();
        float pi();
        int sum(int a, int b);
        SomeClass hey();
    }

    interface ITest2
    {
        void what();
    }

    interface ITest3
    {

    }

    namespace A
    {
        
    }
}

enum What
{
    
}

abstract class Test : SomeClass2, Hey, System.Some.Thing
{
    /*
     * Wild comment block has appeared!
     */

    private static int x, y, z;

    Test() 
    {
        
    }

    public static System.Object[][] Function()
    {
        
    }

    private Test(int a, string str)
    {
        while (true)
        {
            
        }

        for (int x = 0, j = 1; true;)
        {
            break;
            continue;
        }

        foreach (int x in numbers)
        {
            break;
            continue;
        }

        int x, y, z, i;

        //Console.WriteLine("Hello!");
    }

    public static void Something()
    {
        
    }

    public abstract int[][] SomethingAbstract();
}