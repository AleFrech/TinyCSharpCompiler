public class Program
    {
        public static void Main(string[] args)
        {
            var sum = new Sum(50);
            var y= 70;
            System.Console.WriteLine(sum.x);
            System.Console.WriteLine(y+sum.Operate(5,25));

            // Animal animal = new Cat();
            // animal.Talk();

            // animal = new Dog();
            // animal.Talk();
        }
    }