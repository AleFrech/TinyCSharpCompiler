using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationAndExpressionNode : AssignationExpressionNode
	{

        public AssignationAndExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }
	}
}
