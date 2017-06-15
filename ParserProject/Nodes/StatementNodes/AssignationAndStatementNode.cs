using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationAndStatementNode : AssignationNodeStatement
    {
        public AssignationAndStatementNode()
        {
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " &= " + RightValue.GenerateCode().Code };
		}
    }
}
