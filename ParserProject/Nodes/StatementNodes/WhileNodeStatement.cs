using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class WhileNodeStatement:StatementNode
    {
		public ExpressionNode Condition { get; set; }
		public List<StatementNode> TrueStatements { get; set; }

		public WhileNodeStatement(ExpressionNode condition, List<StatementNode> trueStatement)
		{
			Condition = condition;
			TrueStatements = trueStatement;
		}

        public WhileNodeStatement(){
            
        }

    }
}
