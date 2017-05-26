using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class BitAndExpressionNode : BinaryOperatorNode
	{
		public BitAndExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public BitAndExpressionNode(){
            
        }
	}

}
