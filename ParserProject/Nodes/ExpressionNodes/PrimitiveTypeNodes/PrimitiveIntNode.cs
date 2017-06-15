using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveIntNode : PrimitiveTypeNode
	{
		public PrimitiveIntNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Int");
		}

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "int" };
		}
	}
}
