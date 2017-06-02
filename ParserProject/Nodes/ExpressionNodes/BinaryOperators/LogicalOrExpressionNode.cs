using System; 
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class LogicalOrExpressionNode : BinaryOperatorNode
	{

        public LogicalOrExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }
	}

}
