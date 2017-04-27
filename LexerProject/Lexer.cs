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
        private InputString _inputString;
        private Symbol _currentSymbol;
        private readonly IdState _idState;
        private readonly  ReservedWords _reservedWords;
        public Lexer(InputString inputString)
        {
            _inputString = inputString;
            _currentSymbol = _inputString.GetNextSymbol();
            _idState = new IdState();
            _reservedWords = new ReservedWords();
        }

        public Token GetNextToken()
        {
            while (_currentSymbol.Character.IsWhiteSpace())
            {
                _currentSymbol = _inputString.GetNextSymbol();
            }

            if (_currentSymbol.Character == '\0')
            {
                return new Token { Type = TokenType.Eof };
            }

            if (_currentSymbol.Character.IsLetterOrUnderscore())
            {
                return _idState.GetId( ref _currentSymbol,  _inputString);
            }

            throw new LexicalException("Cannot resolve symbol  " + _currentSymbol.Character + "  Line: " + _currentSymbol.Line + " Column: " + _currentSymbol.Column);
        }
    }
}