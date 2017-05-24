using System;
namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public abstract class AccesorExpressionNode: ExpressionNode
    {
        public AccesorExpressionNode Accessor { get; set; }
        public string ParentId { get; set; }
    }
}
