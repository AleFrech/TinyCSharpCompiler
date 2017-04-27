using System;
using System.Text;
using LexerProject.Tokens;
using LexerProject.Tables;
using LexerProject.Extensions;
using LexerProject.Exceptions;
namespace LexerProject.States
{
    public class CharState
    {
        private readonly ReservedChars _reservedChars;

        public CharState()
        {
            _reservedChars = new ReservedChars();
        }

        public Token GetChar(ref Symbol currentSymbol, InputString inputString)
        {
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            lexeme.Append(currentSymbol.Character.ToString());
            currentSymbol=inputString.GetNextSymbol();     
            while (!currentSymbol.Character.IsSingleQuotes())
            {
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
            if (lexeme[1] == 92 || lexeme.Length == 3)
            {

                return new Token
                {
                    Type = TokenType.LitChar,
                    Lexeme =lexeme.ToString(),
                    Column =col,
                    Line =line
                };
            }
            throw new LexicalException("Cannot resolve symbol  " + lexeme.ToString() + "  Line: " + line +
                                           " Column: " + col);
        }
    }
}