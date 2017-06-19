using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
	public class PrimitiveFloatNode : PrimitiveTypeNode
	{
		public PrimitiveFloatNode()
		{
			@Type = CustomTypesTable.Instance.GetType("Float");
		}

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "float",Type = "float"};
		}
	}
}
