using System.Text;
using LexerProject.Extensions;
using LexerProject.Tokens;

namespace LexerProject.States
{
    public class DigitState
    {

        public Token GetDigit(ref Symbol currentSymbol, InputString inputString)
        {
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            if (currentSymbol.Character.Equals('0'))
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
                if (currentSymbol.Character.Equals('x') || currentSymbol.Character.Equals('X'))
                {
                    var t = GetHeximalNumber(ref currentSymbol, inputString,ref lexeme,col,line);
                    if (t != null)
                        return t;
                }
            }
            return GetDecimalNumber(ref currentSymbol, inputString, ref lexeme, col, line);
        }

        private Token GetDecimalNumber(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme, int col, int line)
        {
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (currentSymbol.Character.IsDigit())
            {
                lexeme.Append(currentSymbol.Character);
                 currentSymbol = inputString.GetNextSymbol();
            }
            return new Token
            {
                Type = TokenType.LitNum,
                Lexeme = lexeme.ToString(),
                Column = col,
                Line = line
            };
        }

        private Token GetHeximalNumber(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme,int col,int line)
        {
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (currentSymbol.Character.IsHexValidLetter() || currentSymbol.Character.IsHexValidNumber())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
            }
            if (!lexeme[lexeme.Length - 1].Equals('x') && !lexeme[lexeme.Length - 1].Equals('X'))
            {
                return new Token
                {
                    Type = TokenType.LitNum,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }
            lexeme.Length-=2;
            inputString.ResetCurrentIndexByOne();
			inputString.ResetCurrentIndexByOne();
            inputString.ResetCurrentIndexByOne();
            currentSymbol = inputString.GetNextSymbol();
            return null;
        }
    }
}