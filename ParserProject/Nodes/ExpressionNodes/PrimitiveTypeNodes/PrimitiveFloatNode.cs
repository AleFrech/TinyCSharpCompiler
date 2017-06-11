using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveFloatNode : PrimitiveTypeNode
	{
		public PrimitiveFloatNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Float");
		}
	}
}
