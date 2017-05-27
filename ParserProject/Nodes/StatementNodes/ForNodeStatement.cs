using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForNodeStatement:StatementNode
    {
        public DeclarationAsignationStatement DeclarationAsignation { get; set; }
        public ExpressionNode Expression { get; set; }
		public List<StatementNode> ListStatement { get; set; }
        public List<ExpressionNode> ExpressionList { get; set; }
        public ForNodeStatement(DeclarationAsignationStatement declarationAsignation, ExpressionNode expression, List<ExpressionNode> expressionList, List<StatementNode> statementList)
        {
            DeclarationAsignation = declarationAsignation;
            Expression = expression;
            ListStatement = statementList;
            ExpressionList = expressionList;
        }

        public ForNodeStatement(){
            
        }
    }
}
