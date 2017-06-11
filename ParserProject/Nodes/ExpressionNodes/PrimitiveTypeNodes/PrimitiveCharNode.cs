using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveCharNode : PrimitiveTypeNode
	{
		public PrimitiveCharNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Char");
		}
	}
}
