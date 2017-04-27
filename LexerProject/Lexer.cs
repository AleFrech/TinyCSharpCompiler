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
                var line = _currentSymbol.Line;
                var col = _currentSymbol.Column;
                var lexeme = new StringBuilder();
                while (_currentSymbol.Character.IsLetterOrDigitOrUnderscore())
                {
                    lexeme.Append(_currentSymbol.Character);
                    _currentSymbol = _inputString.GetNextSymbol();
                }

                return new Token()
                {
                    Type = _reservedWords.Collection.ContainsKey(lexeme.ToString().ToLower()) ? _reservedWords.Collection[lexeme.ToString().ToLower()] : TokenType.Id,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }

            throw new LexicalException("Cannot resolve symbol  " + _currentSymbol.Character + "  Line: " + _currentSymbol.Line + " Column: " + _currentSymbol.Column);
        }
    }
}