using System;
namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LogicalOrExpressionNode : BinaryOperatorNode
	{
		public LogicalOrExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public LogicalOrExpressionNode(){
            
        }
	}

}
