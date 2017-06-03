using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationDivExpressionNode : AssignationExpressionNode
	{
        public AssignationDivExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
        }
	}
}
