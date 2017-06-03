using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationEqualExpressionNode : AssignationExpressionNode
    {
        public AssignationEqualExpressionNode(ExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationEqualExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer) ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);


            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, String), String);
        }
    }
}
