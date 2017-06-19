using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class SumExpressionNode : BinaryOperatorNode
	{
        public SumExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);


            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, String), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Integer), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, String), String);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Float), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, String), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Boolean), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, String), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Char), String);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, String), String);

        }

		public override ExpressionCode GenerateCode()
		{
			var leftType = LeftOperand.GenerateCode().Type;
			var rightType = RightOperand.GenerateCode().Type;
			if (leftType != null && rightType != null)
			{
                if (leftType == "float" || rightType == "float")
                {
                    var s = " ( getFloatSumValue( " + LeftOperand.GenerateCode().Code + " , " +
                            RightOperand.GenerateCode().Code + " ) )";

                    return new ExpressionCode { Code = s, Type = "float" };

                }
                else if ((leftType == "int" || rightType == "int") || (leftType=="char" && rightType=="char"))
                {
                    var stringCode = "( getIntSumValue( " + LeftOperand.GenerateCode().Code + " , " +
                                     RightOperand.GenerateCode().Code + " ) )";
                    return new ExpressionCode { Code = stringCode, Type = "int" };
                }
                return new ExpressionCode { Code = "( "+LeftOperand.GenerateCode().Code+" + "+RightOperand.GenerateCode().Code +" )", Type = "string" };
			}
			throw new GenerationException("Cannot generate code from null type operand");
		}

}

}
