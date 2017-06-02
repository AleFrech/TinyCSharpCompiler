using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class RightShiftExpressionNode : BinaryOperatorNode
	{

        public RightShiftExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);

           	OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);

        }
	}

}
