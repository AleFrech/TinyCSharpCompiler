﻿using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;


namespace ParserProject.Nodes.StatementNodes
{
    public class CaseNodeStatement:StatementNode
    {
        public ExpressionNode Condition { get; set; }
        public List<StatementNode> Body { get; set; }
        public BreakNodeStatement BreakNode { get; set; }

		public CaseNodeStatement(ExpressionNode condition, List<StatementNode> body, BreakNodeStatement @break)
		{
			Condition = condition;
			Body = body;
            BreakNode = @break;
		}

        public CaseNodeStatement(){
            
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
