using System;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public abstract class ExpressionNode
    {

		public CustomType Integer = TypesTable.Instance.GetType("Int");
		public CustomType String = TypesTable.Instance.GetType("String");
		public CustomType Boolean = TypesTable.Instance.GetType("Bool");
		public CustomType Char = TypesTable.Instance.GetType("Char");
		public CustomType Float = TypesTable.Instance.GetType("Float");
		public CustomType Enum = TypesTable.Instance.GetType("Enum");
		public CustomType Void = TypesTable.Instance.GetType("Void");
		public UnaryExpressionNode UnaryNode { get; set; }
        public ExpressionNode()
        {
        }
        public abstract CustomType EvaluateSemantic();

    }
}
