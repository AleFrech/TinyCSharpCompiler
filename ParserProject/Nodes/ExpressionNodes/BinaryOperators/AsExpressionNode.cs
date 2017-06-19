using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class AsExpressionNode : BinaryOperatorNode
	{
		public AsExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public AsExpressionNode(){
            
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = "("+LeftOperand.GenerateCode().Code+")",Type=LeftOperand.GenerateCode().Type };
        }
    }

}
