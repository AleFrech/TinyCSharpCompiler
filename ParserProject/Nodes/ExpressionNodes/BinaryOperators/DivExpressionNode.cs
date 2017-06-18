using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class DivExpressionNode : BinaryOperatorNode
	{

        public DivExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); 
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        var leftType = LeftOperand.EvaluateSemantic();
	        var rightType = RightOperand.EvaluateSemantic();
	        if (leftType != null && rightType != null)
	        {
	            if (leftType == Float || rightType == Float)
	            {
	                var s = " ( getFloatDivValue( " + LeftOperand.GenerateCode().Code + " , " +
	                        RightOperand.GenerateCode().Code + " ) )";

	                return new ExpressionCode { Code = s };

	            }
	            var stringCode = "( getIntDivValue( " + LeftOperand.GenerateCode().Code + " , " +
	                             RightOperand.GenerateCode().Code + " ) )";
	            return new ExpressionCode { Code = stringCode };
	        }
	        throw new GenerationException("Cannot generate code from null type operand");
	    }
    }
	}

}
