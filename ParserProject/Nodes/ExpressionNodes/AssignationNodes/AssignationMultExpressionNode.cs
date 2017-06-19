using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationMultExpressionNode : AssignationExpressionNode
    {
        public AssignationMultExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
        }

		public override ExpressionCode GenerateCode()
		{
		    if (LeftValue.GenerateCode().Type == "int")
                return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " *= " + RightValue.GenerateCode().Code ,Type = "int"};
		    if (LeftValue.GenerateCode().Type == "char")
		        return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " *= " + RightValue.GenerateCode().Code, Type = "char" };
		    return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " *= " + RightValue.GenerateCode().Code, Type = "float" };
        }
    }

}
