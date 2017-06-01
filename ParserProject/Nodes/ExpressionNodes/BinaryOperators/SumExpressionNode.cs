using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class SumExpressionNode : BinaryOperatorNode
	{
		public SumExpressionNode(ExpressionNode leftOperand, ExpressionNode rightOperand)
		{
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

        public SumExpressionNode(){
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Float), Float);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(String, Integer), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Integer,String ), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(String, Float), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Float, String), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(String,Boolean ), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Boolean, String), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(String, Char), String);
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Char, String), String);

		}

}

}
