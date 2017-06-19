using System;
using ParserProject.Generation;
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

		public override ExpressionCode GenerateCode()
		{
            if(LeftValue.GenerateCode().Type=="bool" && LeftValue.GenerateCode().Type=="bool")
                return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " &= " + RightValue.GenerateCode().Code,Type ="bool"};
		    if (LeftValue.GenerateCode().Type == "char" && LeftValue.GenerateCode().Type == "char")
		        return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " &= " + RightValue.GenerateCode().Code, Type = "char" };
		    return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " &= " + RightValue.GenerateCode().Code, Type = "int" };

        }
	}
}
