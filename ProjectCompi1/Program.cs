using System;
using System.IO;

namespace ProjectCompi1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal)), "src/test.cs"));
            Console.WriteLine(sourceCode);
            Console.WriteLine("Hello World!");
        }
    }
}