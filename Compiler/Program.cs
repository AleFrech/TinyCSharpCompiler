﻿using System;
using System.IO;
using LexerProject;
using ParserProject;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/testing.cs"));

            try
            {
                var lex = new Lexer(new InputString(sourceCode));
                var parser = new Parser(lex);
                parser.Parse();
                Console.WriteLine("SUCCESS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

    public class Mierda
    {
        //public int c=0;
        //public int x = 1;
        //private int b = 3;
        //public int z = 1,=2,=3
        //public int[] y = {};
    }

}