using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class FloatLiteralExpressionNode:LiteralNodeExpression
    {
        public float Value { get; set; }

        public FloatLiteralExpressionNode(Token lit)
        {
            literal = lit;
            if (literal.Lexeme.Contains("f") || literal.Lexeme.Contains("F"))
            {
                var x = literal.Lexeme.Remove(literal.Lexeme.Length - 1);
                Value = float.Parse(x);
            }
            
        }

        public FloatLiteralExpressionNode(){
            
        }

    }
}
