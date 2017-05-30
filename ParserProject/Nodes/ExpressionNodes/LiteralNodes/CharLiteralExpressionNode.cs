using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class CharLiteralExpressionNode:LiteralNodeExpression
    {
        public char Value { get; set; }

        public CharLiteralExpressionNode(Token lit)
        {
            literal = lit;
            Value = char.Parse(literal.Lexeme);
        }

        public CharLiteralExpressionNode(){
            
        }
    }
}
