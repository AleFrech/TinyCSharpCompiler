using System;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes
{
    public abstract class ExpressionNode
    {

		public PrimitiveTypeNode Integer = TypesTable.Instance.GetType("int");
		public PrimitiveTypeNode String = TypesTable.Instance.GetType("string");
		public PrimitiveTypeNode Boolean = TypesTable.Instance.GetType("bool");
		public PrimitiveTypeNode Char = TypesTable.Instance.GetType("char");
		public PrimitiveTypeNode Float = TypesTable.Instance.GetType("float");
		public UnaryExpressionNode UnaryNode { get; set; }
        public ExpressionNode()
        {
        }
    }
}
