using System;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
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
	}

}
