using System.Collections.Generic;
using LexerProject.Token;

namespace LexerProject.Tables
{
    public class ReserverdSymbols
    {
        public readonly Dictionary<string, TokenType> Collection;

        public ReserverdSymbols()
        {
            Collection = new Dictionary<string, TokenType>
            {
                {"+", TokenType.OpSum},
                {"++", TokenType.OpInc},
                {"-", TokenType.OpSub},
                {"--", TokenType.OpDec},
                {"*", TokenType.OpMul},
                {"%", TokenType.OpMod},
                {"=", TokenType.OpAsgn},
                {"!", TokenType.OpLogicalNot},
                {"==", TokenType.OpEquals},
                {"!=", TokenType.OpNotEquals},
                {">", TokenType.OpGrtThan},
                {"<", TokenType.OpLessThan},
                {">=", TokenType.OpGrtThanOrEqual},
                {"<=", TokenType.OpLessThanOrEqual},
                {"&&", TokenType.OpLogicalAnd},
                {"&", TokenType.OpBinaryAnd},
                {"|", TokenType.OpBinaryOr},
                {"^", TokenType.OpBinaryXor},
                {"~", TokenType.OpBinaryComplement},
                {"<<", TokenType.OpLftShft},
                {">>", TokenType.OpRghtShft},
                {"+=", TokenType.OpAddAsgn},
                {"-=", TokenType.OpSubAsgn},
                {"*=", TokenType.OpMulAsgn},
                {"/=", TokenType.OpDivAsgn},
                {"/", TokenType.OpDiv},
                {"%=", TokenType.OpModAsgn},
                {"<<=", TokenType.OpLftShftAsgn},
                {">>=", TokenType.OpRghtShftAsgn},
                {"&=", TokenType.OpAndAsgn},
                {"|=", TokenType.OpOrAsgn},
                {"^=", TokenType.OpXorAsgn},
                {";", TokenType.EndStatement},
                {",", TokenType.Comma},
                {".", TokenType.Period},
                {"?", TokenType.OpTernario},
                {"(", TokenType.ParOpen},
                {")", TokenType.ParClose},
                {"{", TokenType.KeyOpen},
                {"}", TokenType.KeyClose},
                {"[", TokenType.BraOpen},
                {"]", TokenType.BraClose},
                {":", TokenType.Colon},
                {"->", TokenType.Arrow},
            };
        }

    }
}
