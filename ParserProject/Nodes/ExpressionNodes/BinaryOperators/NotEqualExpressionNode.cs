using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class NotEqualExpressionNode : BinaryOperatorNode
	{
		public NotEqualExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public NotEqualExpressionNode(){
            
        }
	}

}
