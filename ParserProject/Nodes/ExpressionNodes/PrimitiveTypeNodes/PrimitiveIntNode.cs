using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveIntNode : PrimitiveTypeNode
	{
		public PrimitiveIntNode()
		{
			@Type = TypesTable.Instance.GetType("Int");
		}
	}
}
