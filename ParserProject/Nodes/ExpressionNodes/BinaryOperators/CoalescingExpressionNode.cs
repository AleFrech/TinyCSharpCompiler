using System;
namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class CoalescingExpressionNode:BinaryOperatorNode
    {
        public CoalescingExpressionNode(ExpressionNode leftOperand,ExpressionNode rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public CoalescingExpressionNode(){
            
        }
    }

}
