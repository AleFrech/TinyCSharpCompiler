using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class GreaterThanOrEqualExpressionNode : BinaryOperatorNode
	{
		public GreaterThanOrEqualExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public GreaterThanOrEqualExpressionNode(){
            
        }
	}

}
