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
                Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/main.cs"));
            try
            {
//                var x = @"testing
//  this is new line
var div= er/r;
// "" internal string """;
//                 var y = "testing\n this is new line\n\" internal string \"";
                var z = x == y;
                float mierda = 2e-12f;

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