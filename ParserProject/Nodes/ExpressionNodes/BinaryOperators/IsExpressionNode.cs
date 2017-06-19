using ParserProject.Generation;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class IsExpressionNode : BinaryOperatorNode
	{
		public IsExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public IsExpressionNode(){
            
        }

	    public override ExpressionCode GenerateCode()
	    {
	        return new ExpressionCode
	        {
                
	            Code = "( typeof " + LeftOperand.GenerateCode().Code + " === \'" + RightOperand.GenerateCode().Code + "\' )"
	        };
        }
	}

}
