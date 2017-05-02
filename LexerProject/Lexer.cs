using LexerProject.Extensions;
using LexerProject.States;
using LexerProject.Tokens;
using LexerProject.Exceptions;

namespace LexerProject
{
    public class Lexer
    {
        private readonly InputString _inputString;
        private Symbol _currentSymbol;
        private readonly IdState _idState;
        private readonly SymbolState _symbolState;
        private readonly CharState _charState;
        private readonly StringState _stringState;
        private readonly CommentState _commentState;
        private readonly DigitState _digitState;
        private readonly VerbatinState _verbatinState;
        public Lexer(InputString inputString)
        {
            _inputString = inputString;
            _currentSymbol = _inputString.GetNextSymbol();
            _idState = new IdState();
            _symbolState = new SymbolState();
            _charState = new CharState();
            _stringState = new StringState();
            _commentState = new CommentState();
            _digitState= new DigitState();
            _verbatinState = new VerbatinState();
        }

        public Token GetNextToken()
        {
			while (_currentSymbol.Character.IsWhiteSpace())
			{
				_currentSymbol = _inputString.GetNextSymbol();
			}

            _commentState.ConsumeComments(ref _currentSymbol,_inputString);

            if (_currentSymbol.Character.IsEof())
                return new Token { Type = TokenType.Eof };

            if (_currentSymbol.Character.Equals('@'))
                return _verbatinState.GetToken(ref _currentSymbol, _inputString);

            if (_currentSymbol.Character.IsLetterOrUnderscore())
                return _idState.GetId(ref _currentSymbol, _inputString);

            if (_currentSymbol.Character.IsLetterOrDigitOrUnderscore())
                return _digitState.GetDigit(ref _currentSymbol, _inputString);

            if(_currentSymbol.Character.IsSingleQuotes())
                return _charState.GetChar(ref _currentSymbol, _inputString);
            
            if (_currentSymbol.Character.IsDoubleQuotes())
				return _stringState.GetString(ref _currentSymbol, _inputString);
            
			if (_symbolState.IsValid(_currentSymbol.Character.ToString()))
                return _symbolState.GetSymbol(ref _currentSymbol, _inputString);

            throw new LexicalException("Cannot resolve symbol  " + _currentSymbol.Character + "  Line: " + _currentSymbol.Line + " Column: " + _currentSymbol.Column);
        }
    }
}