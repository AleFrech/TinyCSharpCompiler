using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveIntNode : PrimitiveTypeNode
	{
		public PrimitiveIntNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Int");
		}
	}
}
