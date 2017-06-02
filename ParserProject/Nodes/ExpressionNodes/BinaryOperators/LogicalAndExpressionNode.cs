using System;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject
{
    public  class LogicalAndExpressionNode: BinaryOperatorNode
    {

        public LogicalAndExpressionNode(){
		
            OperatorRules.Add(new Tuple<PrimitiveTypeNode, PrimitiveTypeNode>(Boolean, Boolean), Boolean);
        }
    }
}