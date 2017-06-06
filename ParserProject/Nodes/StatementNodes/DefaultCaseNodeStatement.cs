using System;
using System.Collections.Generic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DefaultCaseNodeStatement:StatementNode
	{
        public List<StatementNode> StatementList { get; set; }
		public BreakNodeStatement BreakNode { get; set; }

        public DefaultCaseNodeStatement(List<StatementNode> statementList, BreakNodeStatement @break)
		{
            StatementList = statementList;
            BreakNode=@break;
		}

        public DefaultCaseNodeStatement(){
            
        }

	    public override void EvaluateSemantic()
	    {
	        throw new NotImplementedException();
	    }
	}
}
