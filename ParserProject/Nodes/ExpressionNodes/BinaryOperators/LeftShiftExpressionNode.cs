using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LeftShiftExpressionNode : BinaryOperatorNode
	{

        public LeftShiftExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        var leftType = LeftOperand.EvaluateSemantic();
	        var rightType = RightOperand.EvaluateSemantic();
	        if (leftType != null && rightType != null)
	        {
	            var stringCode = "( getIntLeftShiftValue( " + LeftOperand.GenerateCode().Code + " , " +
	                             RightOperand.GenerateCode().Code + " ) )";
                return new ExpressionCode { Code = stringCode,Type="int" };
	        }
	        throw new GenerationException("Cannot generate code from null type operand");
        }
	}

}
