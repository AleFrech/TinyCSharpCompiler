using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveCharNode : PrimitiveTypeNode
	{
		public PrimitiveCharNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Char");
		}
		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "char", Type = "char"};
		}
	}
}
