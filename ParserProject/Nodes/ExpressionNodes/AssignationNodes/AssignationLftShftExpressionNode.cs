using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationLftShftExpressionNode : AssignationExpressionNode
	{


        public AssignationLftShftExpressionNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Char);
        }

		public override ExpressionCode GenerateCode()
		{
		    if (LeftValue.GenerateCode().Type == "int")
                return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " <<= " + RightValue.GenerateCode().Code,Type = "int"};
		    return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " <<= " + RightValue.GenerateCode().Code, Type = "char" };

        }
	}
}
