using System;
using System.IO;
using LexerProject;
using LexerProject.Tokens;

namespace Compiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var sourceCode = file.GetSourceCode(Path.Combine(AppContext.BaseDirectory.
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/test.cs"));
            try
            {
               
                var lex = new Lexer(new InputString(sourceCode));
                var currentToken = lex.GetNextToken();
                while (currentToken.Type != TokenType.Eof)
                {
                    Console.WriteLine(currentToken);
                    currentToken = lex.GetNextToken();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}