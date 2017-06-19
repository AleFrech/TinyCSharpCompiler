using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class MultExpressionNode : BinaryOperatorNode
	{

        public MultExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
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
			var leftType = LeftOperand.GenerateCode().Type;
			var rightType = RightOperand.GenerateCode().Type;
			if (leftType != null && rightType != null)
			{
				if (leftType == "float" || rightType == "float")
				{
					var s = " ( getFloatMultValue( " + LeftOperand.GenerateCode().Code + " , " +
							RightOperand.GenerateCode().Code + " ) )";

					return new ExpressionCode { Code = s, Type = "float" };

				}
				var stringCode = "( getIntMultValue( " + LeftOperand.GenerateCode().Code + " , " +
								 RightOperand.GenerateCode().Code + " ) )";
				return new ExpressionCode { Code = stringCode, Type = "int" };
			}
			throw new GenerationException("Cannot generate code from null type operand");
		}


	}

}
