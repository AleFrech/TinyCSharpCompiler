using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DefaultCaseNodeStatement:StatementNode
	{
        public List<StatementNode> StatementList { get; set; }
		public string BreakNode { get; set; }

        public DefaultCaseNodeStatement(List<StatementNode> statementList, string @break)
		{
            StatementList = statementList;
            BreakNode=@break;
		}

        public DefaultCaseNodeStatement(){
            
        }

	    public override void EvaluateSemantic()
	    {
	    }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "";
            stringCode += "default : \n";
            foreach(var s in StatementList){
                stringCode += s.GenerateCode().Code;
            }
            stringCode += @BreakNode + "\n";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
