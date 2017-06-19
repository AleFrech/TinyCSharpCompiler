using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LessThanExpressionNode : BinaryOperatorNode
	{
		

        public LessThanExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Boolean); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Boolean);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Enum, Enum), Boolean);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Boolean);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Boolean);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        return new ExpressionCode
	        {
	            Code = "( " + LeftOperand.GenerateCode().Code + " < " + RightOperand.GenerateCode().Code + " )",
                Type ="bool"
	        };
        }
	}

}
