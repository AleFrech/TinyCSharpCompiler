using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic;

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

        public override void EvaluateSemantic()
        {
            var conditionType = Condition.EvaluateSemantic();
            if (CustomTypesTable.Instance.GetType("bool") != conditionType)
                throw new SemanticException($"Condition is not bool {conditionType}");
            
            SymbolTable.CreateContext();
            foreach (var statement in TrueStatements){
                statement.EvaluateSemantic();
            }
            SymbolTable.RemoveContext();
        }
    }
}
