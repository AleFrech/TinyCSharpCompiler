using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForEachNodeStatement:StatementNode
    {
        public TypeExpressionNode Type { get; set; }
        public string IdName { get; set; }
        public ExpressionNode Expression { get; set; }
        public List<StatementNode> ListStatement { get; set; }

        public ForEachNodeStatement(TypeExpressionNode type,string idName,ExpressionNode expression,List<StatementNode> listStatement)
        {
            IdName = idName;
            Type = type;
            Expression = expression;
            ListStatement = listStatement;
        }
    }
}
