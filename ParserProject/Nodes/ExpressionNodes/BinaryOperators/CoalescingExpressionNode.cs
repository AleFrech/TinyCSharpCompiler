using System;
using ParserProject.Generation;

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

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode{Code="( "+LeftOperand.GenerateCode().Code+" || "+RightOperand.GenerateCode().Code+" )"};
        }
    }

}
