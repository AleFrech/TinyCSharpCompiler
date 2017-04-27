using System;
using System.IO;
using LexerProject.Extensions;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/test.cs"));
            var s = @"
";
            var c = s[0];
            Console.WriteLine(c.IsEnter());
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}