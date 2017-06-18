using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LogicalOrExpressionNode : BinaryOperatorNode
	{

        public LogicalOrExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        return new ExpressionCode
	        {
	            Code = "( " + LeftOperand.GenerateCode().Code + " || " + RightOperand.GenerateCode().Code + " )"
	        };
        }
	}

}
