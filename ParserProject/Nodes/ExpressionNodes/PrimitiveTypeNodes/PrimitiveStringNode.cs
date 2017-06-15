using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveStringNode : PrimitiveTypeNode
	{
		public PrimitiveStringNode()
		{
			@Type = CustomTypesTable.Instance.GetType("String");
		}

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "string" };
		}
	}
}
