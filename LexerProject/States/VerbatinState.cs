using System.Text;
using LexerProject.Exceptions;
using LexerProject.Extensions;
using LexerProject.Tokens;

namespace LexerProject.States
{
    public class VerbatinState
    {
        public Token GetToken(ref Symbol currentSymbol, InputString inputString)
        {
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            if (currentSymbol.Character.IsLetterOrUnderscore())
            {
                while (currentSymbol.Character.IsLetterOrDigitOrUnderscore())
                {
                    lexeme.Append(currentSymbol.Character);
                    currentSymbol = inputString.GetNextSymbol();
                }
                return new Token
                {
                    Type = TokenType.Id,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }
            throw new LexicalException("Cannot resolve symbol  " + lexeme.ToString() + "  Line: " + line + " Column: " + col);
        }
    }
}
