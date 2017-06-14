﻿﻿﻿﻿using System;
using System.IO;
using LexerProject;
using ParserProject;
    using ParserProject.Semantic;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {

            var file = new FileManager();

            //var sourceCode = file.GetSourceCode("./TestProject/Level1/Test3.cs");

            //try
            //{
            //    var lex = new Lexer(new InputString(sourceCode));
            //    var parser = new Parser(lex);
            //    var tree = parser.Parse();
            //    Console.WriteLine("SUCCESS");
            //}


            try
            {
                var treeList = file.GetTreeListFromFiles();
                TypeTable.FillTable(treeList);
                var x=TypeTable.TypeList;
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
