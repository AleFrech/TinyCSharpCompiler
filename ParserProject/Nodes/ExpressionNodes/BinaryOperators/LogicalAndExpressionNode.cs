using System;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject
{
    public  class LogicalAndExpressionNode: BinaryOperatorNode
    {

        public LogicalAndExpressionNode(){
		
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }
    }
}