﻿using System.Text;
using LexerProject.Exceptions;
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
                    lexeme.Length -= 2;
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
 
            while (currentSymbol.Character.IsDigit())
            {
                lexeme.Append(currentSymbol.Character);
                 currentSymbol = inputString.GetNextSymbol();
            }
            if (currentSymbol.Character.Equals('.'))
            {
                return GetFloatNumber(ref currentSymbol, inputString, ref lexeme, col, line);
            }
            if (currentSymbol.Character.Equals('E') || currentSymbol.Character.Equals('e'))
            {
                return GetExponent(ref currentSymbol, inputString, ref lexeme, col, line);
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
            if (currentSymbol.Character.Equals('E') || currentSymbol.Character.Equals('e'))
            {
                return GetExponent(ref currentSymbol, inputString, ref lexeme, col, line);
            }
            if ((currentSymbol.Character.Equals(('f')) || currentSymbol.Character.Equals(('F'))) && int.TryParse(lexeme[lexeme.Length - 1].ToString(), out result))
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
                return new Token
                {
                    Type = TokenType.LitFloat,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }
            throw new LexicalException("Invalid float syntax  " + lexeme.ToString() + "  Line: " + line +
                                       " Column: " + col);
        }

        private Token GetExponent(ref Symbol currentSymbol, InputString inputString, ref StringBuilder lexeme, int col,
            int line)
        {
            int result;
            lexeme.Append(currentSymbol.Character);
            currentSymbol = inputString.GetNextSymbol();
            while (currentSymbol.Character.IsDigit())
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
            }
            if (lexeme[lexeme.Length - 1].Equals('e') || lexeme[lexeme.Length - 1].Equals('E'))
            {
                if (currentSymbol.Character.Equals('-'))
                {
                    lexeme.Append(currentSymbol.Character);
                    currentSymbol = inputString.GetNextSymbol();
                    while (currentSymbol.Character.IsDigit())
                    {
                        lexeme.Append(currentSymbol.Character);
                        currentSymbol = inputString.GetNextSymbol();
                    }
                }
            }
            if ((currentSymbol.Character.Equals(('f')) || currentSymbol.Character.Equals(('F'))) && int.TryParse(lexeme[lexeme.Length - 1].ToString(), out result))
            {
                lexeme.Append(currentSymbol.Character);
                currentSymbol = inputString.GetNextSymbol();
                return new Token
                {
                    Type = TokenType.LitFloat,
                    Lexeme = lexeme.ToString(),
                    Column = col,
                    Line = line
                };
            }
            throw new LexicalException("Invalid float syntax  " + lexeme.ToString() + "  Line: " + line +
                                       " Column: " + col);
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