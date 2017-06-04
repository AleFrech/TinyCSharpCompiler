using System;
using System.Collections.Generic;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForEachNodeStatement:StatementNode
    {
        public TypeExpressionNode Type { get; set; }
        public Token IdName { get; set; }
        public ExpressionNode Expression { get; set; }
        public List<StatementNode> ListStatement { get; set; }

        public ForEachNodeStatement(TypeExpressionNode type,Token idName,ExpressionNode expression,List<StatementNode> listStatement)
        {
            IdName = idName;
            Type = type;
            Expression = expression;
            ListStatement = listStatement;
        }

        public ForEachNodeStatement(){
            
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
