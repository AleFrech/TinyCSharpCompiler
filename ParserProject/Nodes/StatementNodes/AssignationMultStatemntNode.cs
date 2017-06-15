using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationMultStatemntNode: AssignationNodeStatement
    {

        public AssignationMultStatemntNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " *= " + RightValue.GenerateCode().Code };
		}
    }

}
