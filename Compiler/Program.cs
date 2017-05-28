﻿﻿﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
   using System.Security.Cryptography.X509Certificates;
   using LexerProject;
using ParserProject;
   using ParserProject.Nodes.ExpressionNodes.PreIdNodes;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/main.cs"));

            try
            {
                var lex = new Lexer(new InputString(sourceCode));
                var parser = new Parser(lex);
                var tree =parser.Parse();
                file.WriteXml(tree);

				Console.WriteLine("SUCCESS");
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
