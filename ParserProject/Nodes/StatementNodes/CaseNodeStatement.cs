using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;


namespace ParserProject.Nodes.StatementNodes
{
    public class CaseNodeStatement:StatementNode
    {
        public ExpressionNode Condition { get; set; }
        public List<StatementNode> Body { get; set; }
        public string BreakNode { get; set; }

		public CaseNodeStatement(ExpressionNode condition, List<StatementNode> body, string @break)
		{
			Condition = condition;
			Body = body;
            BreakNode = @break;
		}

        public CaseNodeStatement(){
            
        }

        public void EvaluateSemantic(CustomType type)
        {
            var conditionType = Condition.EvaluateSemantic();
            if (conditionType != type)
                throw new SemanticException("Invalid Expression");
			SymbolTable.CreateContext();
			foreach (var statement in Body)
			{
				statement.EvaluateSemantic();
			}
			SymbolTable.RemoveContext();
        }

        public override void EvaluateSemantic()
        {
            
        }

        public override ExpressionCode GenerateCode()
        {
			var stringCode = "";
            stringCode += "case "+Condition.GenerateCode().Code+" :\n";
            foreach(var s in Body){
                stringCode += s.GenerateCode().Code;
            }
            stringCode += @BreakNode+"\n";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
