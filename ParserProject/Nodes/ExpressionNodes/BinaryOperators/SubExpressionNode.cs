using System;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class SubExpressionNode : BinaryOperatorNode
	{
        
        public SubExpressionNode(){

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
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
	}

}
