using System;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class BitAndExpressionNode : BinaryOperatorNode
	{
        public BitAndExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
        }
	}

}
