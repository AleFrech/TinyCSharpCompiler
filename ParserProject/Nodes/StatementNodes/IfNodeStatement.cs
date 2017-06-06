using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class IfNodeStatement:StatementNode
    {
        public ExpressionNode Condition { get; set; }
        public List<StatementNode> TrueStatements { get; set; }
        public List<StatementNode> FalseStatements { get; set; }

        public IfNodeStatement(ExpressionNode condition, List<StatementNode> trueStatement)
        {
            Condition = condition;
            TrueStatements = trueStatement;
            FalseStatements = null;
        }

        public IfNodeStatement(ExpressionNode condition, List<StatementNode> trueStatement, List<StatementNode> falseStatement)
		{
			Condition = condition;
			TrueStatements = trueStatement;
            FalseStatements = falseStatement;
		}

        public IfNodeStatement(){
            
        }

        public override void EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
