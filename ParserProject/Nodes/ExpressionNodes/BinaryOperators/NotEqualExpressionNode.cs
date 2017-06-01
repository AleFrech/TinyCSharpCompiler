using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class NotEqualExpressionNode : BinaryOperatorNode
	{
		

        public NotEqualExpressionNode(){
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Integer), Boolean); ;
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Integer), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Char), Boolean);


			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Float), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Float), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Integer), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Float), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Char), Boolean);

			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Char), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Boolean, Boolean), Boolean);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(String, String), Boolean);
        }
	}

}
