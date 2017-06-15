using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationSumStatementNode: AssignationNodeStatement
    {
        public AssignationSumStatementNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);


            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, String), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Integer), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Float), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Boolean), String);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(String, Char), String);
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " += " + RightValue.GenerateCode().Code };
		}
    }
}
