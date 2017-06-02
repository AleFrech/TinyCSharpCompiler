using System;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LogicalOrExpressionNode : BinaryOperatorNode
	{

        public LogicalOrExpressionNode(){
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Boolean, Boolean), Boolean);
        }
	}

}
