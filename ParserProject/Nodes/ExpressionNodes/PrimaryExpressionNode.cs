using System;
namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimaryExpressionNode:ExpressionNode
    {
        public UnaryExpressionNode unaryNode { get; set; }
        public PrimaryExpressionNode()
        {
        }
    }
}
