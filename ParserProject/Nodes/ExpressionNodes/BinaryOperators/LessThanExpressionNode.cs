using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class LessThanExpressionNode : BinaryOperatorNode
	{
		

        public LessThanExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Boolean); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Boolean);


			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Boolean);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Boolean);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Boolean);
        }

	}

}
