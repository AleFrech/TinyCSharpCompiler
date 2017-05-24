using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForEachNodeStatement:StatementNode
    {
        public IdExpressionNode Id { get; set; }
        ExpressionNode Expression { get; set; }
        public List<StatementNode> ListStatement { get; set; }

        public ForEachNodeStatement(IdExpressionNode id,ExpressionNode expression,List<StatementNode> listStatement)
        {
            Id = id;
            Expression = expression;
            ListStatement = listStatement;
        }
    }
}
