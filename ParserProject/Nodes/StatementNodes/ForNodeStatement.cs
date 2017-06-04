using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForNodeStatement:StatementNode
    {
        public StatementNode DeclarationAsignation { get; set; }
        public ExpressionNode Expression { get; set; }
        public List<ExpressionNode> ExpressionList { get; set; }
        public List<StatementNode> ListStatement { get; set; }
        public ForNodeStatement(StatementNode declarationAsignation, ExpressionNode expression, List<ExpressionNode> expressionList, List<StatementNode> statementList)
        {
            DeclarationAsignation = declarationAsignation;
            Expression = expression;
            ListStatement = statementList;
            ExpressionList = expressionList;
        }

        public ForNodeStatement(){
            
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
