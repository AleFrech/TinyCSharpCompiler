using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject
{
    internal class LogicalAndExpressionNode: BinaryOperatorNode
    {

        public LogicalAndExpressionNode(ExpressionNode left, ExpressionNode right) 
        {
            LeftOperand = left;
            RightOperand = right;
        }
    }
}