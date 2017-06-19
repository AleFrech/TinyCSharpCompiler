using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class BitOrExpressionNode : BinaryOperatorNode
	{

        public BitOrExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }

	    public override ExpressionCode GenerateCode()
	    {
			var leftType = LeftOperand.GenerateCode().Type;
			var rightType = RightOperand.GenerateCode().Type;
	        if (leftType != null && rightType != null)
	        {
	            if (leftType == "bool" && rightType == "bool")
	            {
	                var s = "( getBoolBitOrValue( " + LeftOperand.GenerateCode().Code + " , " +
	                        RightOperand.GenerateCode().Code + " ) )";

                    return new ExpressionCode {Code = s,Type="bool"};

	            }
	            var stringCode = "( getIntBitOrValue( " + LeftOperand.GenerateCode().Code + " , " +
	                             RightOperand.GenerateCode().Code + " ) )";
                return new ExpressionCode {Code = stringCode,Type="int"};
	        }
            throw new GenerationException("Cannot generate code from null type operand");
	    }
    }
}
