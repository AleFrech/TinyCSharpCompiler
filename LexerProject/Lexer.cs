using System;
using System.Text;
using LexerProject.Extensions;
using LexerProject.States;
using LexerProject.Tokens;
using LexerProject.Exceptions;
using LexerProject.Tables;

namespace LexerProject
{
    public class Lexer
    {
        InputString _inputString;
        Symbol _currentSymbol;
        readonly IdState _idState;
        readonly SymbolState _symbolState; 
        readonly ReservedWords _reservedWords;
        readonly CharState _charState;
        readonly StringState _stringState;
        public Lexer(InputString inputString)
        {
            _inputString = inputString;
            _currentSymbol = _inputString.GetNextSymbol();
            _idState = new IdState();
            _symbolState = new SymbolState();
            _reservedWords = new ReservedWords();
            _charState = new CharState();
            _stringState = new StringState();
        }

        public Token GetNextToken()
        {
            while (_currentSymbol.Character.IsWhiteSpace())
            {
                _currentSymbol = _inputString.GetNextSymbol();
            }

            if (_currentSymbol.Character.IsEof())
            {
                return new Token { Type = TokenType.Eof };
            }

            if (_currentSymbol.Character.IsLetterOrUnderscore())
            {
                return _idState.GetId( ref _currentSymbol,  _inputString);
            }

            if(_currentSymbol.Character.IsSingleQuotes())
            {
                return _charState.GetChar(ref _currentSymbol, _inputString);
            }
            if (_currentSymbol.Character.IsDoubleQuotes())
			{
				return _stringState.GetString(ref _currentSymbol, _inputString);
			}
			if (_symbolState.IsValid(_currentSymbol.Character.ToString()))
                {
                    return _symbolState.GetSymbol(ref _currentSymbol, _inputString);
                }

            throw new LexicalException("Cannot resolve symbol  " + _currentSymbol.Character + "  Line: " + _currentSymbol.Line + " Column: " + _currentSymbol.Column);
        }
    }
}