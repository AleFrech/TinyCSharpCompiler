using System.Text;
using LexerProject.Tokens;
using LexerProject.Tables;

namespace LexerProject.States
{
    public class SymbolState
    {
        private readonly ReserverdSymbols _reserverdSymbols;

        public SymbolState()
        {
            _reserverdSymbols = new ReserverdSymbols();
        }
        public Token GetSymbol(ref Symbol currentSymbol,InputString inputString)
        {
			var line = currentSymbol.Line;
			var col = currentSymbol.Column;
			var lexeme = new StringBuilder();
            var sym = currentSymbol.Character.ToString();
            while (IsValid(sym))
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
                sym += currentSymbol.Character.ToString();
            }
            return new Token
	            {
	                Type = _reserverdSymbols.Collection[lexeme.ToString().ToLower()],
	                Lexeme = lexeme.ToString(),
	                Column = col,
	                Line = line
	            };
                
        }

        public bool IsValid(string symbol)
        {
            return _reserverdSymbols.Collection.ContainsKey(symbol);
        }
    }
}
