using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
	public class PrimitiveTypeProductionNode : TypeProductionNode
	{
		public PrimitiveTypeNode PrimitiveType { get; set; }
        public List<RankSpeciferNode> RankSpecifiers { get; set; }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "";
            stringCode += PrimitiveType.GenerateCode().Code;
			if (RankSpecifiers != null)
			{
				foreach (var rank in RankSpecifiers)
					stringCode += rank.GenerateCode().Code;
			}
			return new ExpressionCode { Code = stringCode };
        }
    }
}
