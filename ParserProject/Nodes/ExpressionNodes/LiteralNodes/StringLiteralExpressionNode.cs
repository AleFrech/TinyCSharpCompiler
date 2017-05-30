using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class StringLiteralExpressionNode:LiteralNodeExpression
    {
        public string Value { get; set; }

        public StringLiteralExpressionNode(Token lit)
        {
            literal = lit;
            Value = literal.Lexeme;
        }

        public StringLiteralExpressionNode(){
            
        }
    }
}
