using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public abstract class AccesorExpressionNode: ExpressionNode
    {
        public AccesorExpressionNode Accessor { get; set; }
        public Token ParentId { get; set; }
    }
}
