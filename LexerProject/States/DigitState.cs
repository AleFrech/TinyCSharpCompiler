﻿using System.Text;
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
                if (currentSymbol.Character.Equals('.'))
                {
                    var t = GetFloatNumber(ref currentSymbol, inputString,ref lexeme,col,line);
                    if (t != null)
                        return t;
                }
                if (currentSymbol.Character.Equals(('B')) || currentSymbol.Character.Equals(('b')))
                {
                    lexeme.Append(currentSymbol.Character);
                    currentSymbol = inputString.GetNextSymbol();
                    while (currentSymbol.Character.Equals('0') || currentSymbol.Character.Equals('1'))
                    {
                        lexeme.Append(currentSymbol.Character);
                        currentSymbol = inputString.GetNextSymbol();
                    }
                    if(lexeme[lexeme.Length-1].Equals('0') && lexeme[lexeme.Length-1].Equals('1'))
                        return new Token
                        {
                            Type = TokenType.LitNum,
                            Lexeme = lexeme.ToString(),
                            Column = col,
                            Line = line
                        };
                    lexeme.Length-=2;
                    inputString.ResetCurrentIndexByOne();
                    inputString.ResetCurrentIndexByOne();
                    inputString.ResetCurrentIndexByOne();
                    currentSymbol = inputString.GetNextSymbol();
                }

            }
            return GetDecimalNumber(ref currentSymbol, inputString, ref lexeme, col, line);
        }

        private Token GetDecimalNumber(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme, int col, int line)
        {
            int result;
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (currentSymbol.Character.IsDigit())
            {
                lexeme.Append(currentSymbol.Character);
                 currentSymbol = inputString.GetNextSymbol();
            }
            if (currentSymbol.Character.Equals('.') && int.TryParse(lexeme.ToString(), out result))
            {
                var t = GetFloatNumber(ref currentSymbol, inputString,ref lexeme,col,line);
                if (t != null)
                    return t;
            }
            return new Token
            {
                Type = TokenType.LitNum,
                Lexeme = lexeme.ToString(),
                Column = col,
                Line = line
            };
        }

        private Token GetFloatNumber(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme, int col, int line)
        {
            int result;
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (currentSymbol.Character.IsDigit())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
            }
            if (int.TryParse(lexeme[lexeme.Length - 1].ToString(), out result))
            {
                if (currentSymbol.Character.Equals('E') || currentSymbol.Character.Equals('e'))
                {
                    var t = GetExponent(ref currentSymbol, inputString, ref lexeme, col, line);
                    if (t != null)
                        return t;
                }
                if (!lexeme[lexeme.Length - 1].Equals('.'))
                {
                    if (currentSymbol.Character.Equals('F') || currentSymbol.Character.Equals('f'))
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
                lexeme.Length--;
                inputString.ResetCurrentIndexByOne();
                currentSymbol = inputString.GetNextSymbol();
            }
            lexeme.Length--;
            inputString.ResetCurrentIndexByOne();
            inputString.ResetCurrentIndexByOne();
            currentSymbol = inputString.GetNextSymbol();
            return null;
        }

        private Token GetExponent(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme, int col, int line)
        {
            throw new System.NotImplementedException();
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