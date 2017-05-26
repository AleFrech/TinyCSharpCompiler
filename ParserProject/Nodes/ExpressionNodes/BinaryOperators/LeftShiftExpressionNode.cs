using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class LeftShiftExpressionNode : BinaryOperatorNode
	{
        public LeftShiftExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public LeftShiftExpressionNode(){
            
        }
	}

}
