using System;
using System.IO;
using System.Reflection;

namespace ProjectCompi1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"src\", "test.cs"));
            Console.WriteLine("Hello World!");
        }
    }
}