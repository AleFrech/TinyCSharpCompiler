using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class ModExpressionNode : BinaryOperatorNode
	{

        public ModExpressionNode(){
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Char), Integer);

            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Char), Integer);

			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Float), Float);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Float), Float);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Integer), Float);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Float), Float);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Char), Float);
        }
	}

}
