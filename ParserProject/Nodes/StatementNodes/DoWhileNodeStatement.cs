using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DoWhileNodeStatement:StatementNode
    {
		public ExpressionNode Condition { get; set; }
		public List<StatementNode> TrueStatements { get; set; }

		public DoWhileNodeStatement(ExpressionNode condition, List<StatementNode> trueStatement)
		{
			Condition = condition;
			TrueStatements = trueStatement;
		}

        public DoWhileNodeStatement(){
            
        }

        public override void EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
