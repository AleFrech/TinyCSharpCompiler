using System;
using System.Text;
using LexerProject.Tokens;
using LexerProject.Tables;
using LexerProject.Extensions;
using LexerProject.Exceptions;
namespace LexerProject.States
{
    public class StringState
    {
        private readonly ReservedChars _reservedChars;

        public StringState()
        {
            _reservedChars=new ReservedChars();

        }

        public Token GetString(ref Symbol currentSymbol, InputString inputString)
        {
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            lexeme.Append(currentSymbol.Character.ToString());
            currentSymbol=inputString.GetNextSymbol();     
            while (!currentSymbol.Character.IsDoubleQuotes())
            {
                if (currentSymbol.Character.IsEof())
                    break;
                
                if (currentSymbol.Character == 92)
                    {
                        var resrvedchar = currentSymbol.Character.ToString();
                        var p = inputString.GetNextSymbol();
                        resrvedchar += p.Character.ToString();
                        lexeme.Append(resrvedchar);
                        if (!_reservedChars.Collection.Contains(resrvedchar))
                            throw new LexicalException("Cannot resolve symbol  " + lexeme.ToString() + "  Line: " + line +
                                               " Column: " + col);
                    }
                    else
                    {
                        lexeme.Append(currentSymbol.Character);
                    }
                currentSymbol = inputString.GetNextSymbol();
            }
            lexeme.Append(currentSymbol.Character);
            currentSymbol=inputString.GetNextSymbol();
            var x = lexeme.ToString();
            if (!lexeme.ToString().Contains("\n") && !lexeme.ToString().Contains("\r"))
            {
                if (lexeme[lexeme.Length-1].Equals('"'))
                {

                    return new Token
                    {
                        Type = TokenType.LitString,
                        Lexeme = lexeme.ToString(),
                        Column = col,
                        Line = line
                    };
                }
            }
            throw new LexicalException("String not  closed   Line: " + line +
                                           " Column: " + col);
        }
    }
}
