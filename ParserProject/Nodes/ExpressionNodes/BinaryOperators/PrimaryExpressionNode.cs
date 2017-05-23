using System;
namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class PrimaryExpressionNode:ExpressionNode
    {
        public UnaryExpressionNode unaryNode { get; set; }
        public PrimaryExpressionNode()
        {
        }
    }
}
