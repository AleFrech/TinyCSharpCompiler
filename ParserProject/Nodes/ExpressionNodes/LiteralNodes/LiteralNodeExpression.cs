using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public abstract class LiteralNodeExpression : ExpressionNode
    {
        public Token literal { get; set; }
        public LiteralNodeExpression()
        {
        }
    }
}
