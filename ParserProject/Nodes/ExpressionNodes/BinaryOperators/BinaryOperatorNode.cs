using System;
namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public abstract class BinaryOperatorNode : ExpressionNode
    {
        public ExpressionNode LeftOperand { get; set; }
        public ExpressionNode RightOperand { get; set; }
    }
}
