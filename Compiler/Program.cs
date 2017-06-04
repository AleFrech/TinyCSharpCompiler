﻿﻿﻿﻿using System;
using System.IO;
using LexerProject;
using ParserProject;
using ParserProject.Apis;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/test1.cs"));

            try
            {
                var lex = new Lexer(new InputString(sourceCode));
                var parser = new Parser(lex);
                var tree =parser.Parse();
				Console.WriteLine("SUCCESS");
                var api= new ApiManager(tree);
                var claNode = api.GetClass("VinculacionBackend.Services.StudentsServices");
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadLine();
        }
     }
}
