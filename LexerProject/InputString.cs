using LexerProject.Extensions;
using LexerProject.Interfaces;

namespace LexerProject
{
        public class InputString : IInput
        {
            public string SourceCode;
            public int CurrentChar;
            public int Column;
            public int Line;

            public InputString(string input)
            {
                SourceCode = input;
                Line = 1;
                Column = 1;
                CurrentChar = 0;
            }

            
            public Symbol GetNextSymbol()
            {
                if (CurrentChar < SourceCode.Length)
                {
                    if (SourceCode[CurrentChar]=='\r')
                    {
                        CurrentChar++;
                        Line++;
                        Column = 1;
                        return new Symbol { Character = SourceCode[CurrentChar++], Column = Column, Line = Line };
                 
                    }
                    if (SourceCode[CurrentChar] == '\n')
                    {
                        Line ++;
                        Column = 1;
                        return new Symbol { Character = SourceCode[CurrentChar ++], Column = Column, Line = Line };
                    }

                    return new Symbol { Character = SourceCode[CurrentChar++], Column = Column++, Line = Line };
                }
                return new Symbol {Character = '\0', Column = Column, Line = Line};
            }
        }
}
