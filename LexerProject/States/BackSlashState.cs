using System.Text;
using LexerProject.Tokens;
using LexerProject.Extensions;

namespace LexerProject.States
{
    public class BackSlashState
    {
        public Token GetToken(ref Symbol currentSymbol,InputString inputString){
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            lexeme.Append(currentSymbol.Character.ToString());
            currentSymbol=inputString.GetNextSymbol();
            if (currentSymbol.Character.Equals('/'))
            {
                lexeme.Append(currentSymbol.Character.ToString());
                currentSymbol=inputString.GetNextSymbol();
                while (!currentSymbol.Character.Equals('\r') && !currentSymbol.Character.Equals('\n') && !currentSymbol.Character.IsEof())
                {
                    currentSymbol = inputString.GetNextSymbol();
                }
                return new Token { Lexeme = lexeme.ToString(), Column = col, Line = line, Type = TokenType.Cmnt };
            }

            if (currentSymbol.Character.Equals('*'))
                return null;
            if (currentSymbol.Character.Equals('='))
            {
                lexeme.Append(currentSymbol.Character.ToString());
                currentSymbol = inputString.GetNextSymbol();
                return new Token { Lexeme = lexeme.ToString(), Column = col, Line = line, Type = TokenType.OpDivAsgn };
            }
            else
            {
                return new Token {Lexeme = lexeme.ToString(),Column = col,Line = line,Type = TokenType.OpDiv};
            }
        }
    }
}
