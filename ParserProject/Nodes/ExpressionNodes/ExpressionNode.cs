using System;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public abstract class ExpressionNode
    {
        public UnaryExpressionNode UnaryNode { get; set; }
        public ExpressionNode()
        {
        }
    }
}
