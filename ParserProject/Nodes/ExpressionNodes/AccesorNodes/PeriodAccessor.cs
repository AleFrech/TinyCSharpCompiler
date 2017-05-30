using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public class PeriodAccessor : AccesorExpressionNode
    {
        public Token Id { get; set; }
    }
}
