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
		public PrimitiveTypeNode primitiveType { get; set; }
        public List<RankSpeciferNode> rankSpecifiers { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "";
            stringCode += primitiveType.GenerateCode().Code;
			if (rankSpecifiers != null)
			{
				foreach (var rank in rankSpecifiers)
					stringCode += rank.GenerateCode().Code;
			}
			return new ExpressionCode { Code = stringCode };
        }
    }
}
