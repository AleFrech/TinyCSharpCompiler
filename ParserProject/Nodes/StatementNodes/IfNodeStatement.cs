using System;
using System.Collections.Generic;
using ParserProject.Generation;
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
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "if (" + Condition.GenerateCode().Code + ") {\n";
            foreach (var s in TrueStatements){
                stringCode += s.GenerateCode().Code;
            }
            stringCode += "}\n";
            if(FalseStatements!=null){
                stringCode += "else {\n";
                foreach (var s in FalseStatements)
				{
					stringCode += s.GenerateCode().Code;
				}
				stringCode += "}\n";
            }
            return new ExpressionCode { Code = stringCode };
        }
    }
}
