using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForNodeStatement:StatementNode
    {
		public ExpressionNode Expression { get; set; }
		public List<StatementNode> ListStatement { get; set; }
        public List<ExpressionNode> ExpressionList { get; set; }
        public ForNodeStatement(ExpressionNode expression, List<ExpressionNode> expressionList,List<StatementNode> statementList)
        {
            Expression = expression;
            ListStatement = statementList;
            ExpressionList = expressionList;
        }
    }
}
