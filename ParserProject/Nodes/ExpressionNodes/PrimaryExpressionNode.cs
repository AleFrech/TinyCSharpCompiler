using System;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimaryExpressionNode:ExpressionNode
    {
        public UnaryExpressionNode UnaryNode { get; set; }
        public PrimaryExpressionNode()
        {
            
        }
    }
}
