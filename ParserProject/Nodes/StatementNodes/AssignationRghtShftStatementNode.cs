using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationRghtShftStatementNode : AssignationNodeStatement
    {
        public AssignationRghtShftStatementNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = LeftValue.GenerateCode().Code + " >>= " + RightValue.GenerateCode().Code };
		}
	}
}
