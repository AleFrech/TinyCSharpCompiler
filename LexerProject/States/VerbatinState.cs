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
            if (currentSymbol.Character.IsDoubleQuotes())
            {

                return GetVerbatinString(ref currentSymbol, inputString, ref lexeme, col, line);

            }
            throw new LexicalException("Cannot resolve symbol  " + lexeme.ToString() + "  Line: " + line + " Column: " + col);
        }


        public Token GetVerbatinString(ref Symbol currentSymbol, InputString inputString,ref StringBuilder lexeme, int col, int line)
        {
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (!currentSymbol.Character.IsDoubleQuotes() && !currentSymbol.Character.IsEof())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
            }
            if (currentSymbol.Character.IsDoubleQuotes())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
                if(currentSymbol.Character.IsDoubleQuotes())
                    return GetVerbatinString(ref currentSymbol, inputString, ref lexeme, col, line);
                return new Token
                {
                    Type = TokenType.LitString,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }
            throw new LexicalException("Cannot resolve symbol  " + lexeme.ToString() + "  Line: " + line + " Column: " + col);
        }

    }
}
