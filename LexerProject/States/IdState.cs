using System.Text;
using LexerProject.Extensions;
using LexerProject.Tables;
using LexerProject.Tokens;

namespace LexerProject.States
{
    public class IdState
    {
        private readonly ReservedWords _reservedWords;

        public IdState()
        {
            _reservedWords = new ReservedWords();
        }
        public Token GetId( ref Symbol currentSymbol,  InputString inputString)
        {
            var line = currentSymbol.Line;
            var col = currentSymbol.Column;
            var lexeme = new StringBuilder();
            while (currentSymbol.Character.IsLetterOrDigitOrUnderscore())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
            }

            return new Token
            {
                Type = _reservedWords.Collection.ContainsKey(lexeme.ToString().ToLower()) ? _reservedWords.Collection[lexeme.ToString().ToLower()] : TokenType.Id,
                Lexeme = lexeme.ToString(),
                Column = col,
                Line = line
            };
        }
    }
}
