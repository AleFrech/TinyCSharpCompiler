using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationLftShftStatementNode : AssignationNodeStatement
    {
        public AssignationLftShftStatementNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Char);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Char);
        }
	}
}
