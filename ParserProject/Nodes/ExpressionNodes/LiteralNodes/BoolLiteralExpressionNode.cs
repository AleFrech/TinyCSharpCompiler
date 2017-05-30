using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class BoolLiteralExpressionNode:LiteralNodeExpression
    {
        public bool Value { get; set; }

        public BoolLiteralExpressionNode(Token lit)
        {
            literal = lit;
            Value = bool.Parse(literal.Lexeme);
        }

        public BoolLiteralExpressionNode(){
            
        }
    }
}
