using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class GreaterThanExpressionNode : BinaryOperatorNode
	{
		public GreaterThanExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public GreaterThanExpressionNode(){
            
        }
	}

}
