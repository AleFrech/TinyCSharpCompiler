using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationXorStatementNode : AssignationNodeStatement
    {

        public AssignationXorStatementNode(){
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }
	}
}
