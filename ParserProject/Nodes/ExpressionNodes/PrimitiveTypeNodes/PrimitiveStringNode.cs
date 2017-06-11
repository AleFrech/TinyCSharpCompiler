using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveStringNode : PrimitiveTypeNode
	{
		public PrimitiveStringNode()
		{
			@Type = CustomTypesTable.Instance.GetType("String");
		}
	}
}
