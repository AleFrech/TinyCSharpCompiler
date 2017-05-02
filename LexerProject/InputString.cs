using LexerProject.Interfaces;

namespace LexerProject
{
        public class InputString : IInput
        {
            private readonly string _sourceCode;
            private int _currentChar;
            private int _column;
            private int _line;

            public InputString(string input)
            {
                _sourceCode = input;
                _line = 1;
                _column = 1;
                _currentChar = 0;
            }

            
            public Symbol GetNextSymbol()
            {
                if (_currentChar < _sourceCode.Length)
                {
                    if (_sourceCode[_currentChar]=='\r')
                    {
                        _currentChar++;
                        _line++;
                        _column = 1;
                        return new Symbol { Character = _sourceCode[_currentChar++], Column = _column, Line = _line };
                 
                    }
                    if (_sourceCode[_currentChar] == '\n')
                    {
                        _line ++;
                        _column = 1;
                        return new Symbol { Character = _sourceCode[_currentChar ++], Column = _column, Line = _line };
                    }

                    return new Symbol { Character = _sourceCode[_currentChar++], Column = _column++, Line = _line };
                }
                return new Symbol {Character = '\0', Column = _column, Line = _line};
            }

            public void RemoveConsumedCaracters(int count)
            {
                _currentChar -= count;
                _column -= count;
            }

        }
}
