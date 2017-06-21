using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class IdTypeProductionNode:TypeProductionNode
    {
        public IdTypeNode IdType { get; set; }
		public List<RankSpeciferNode> RankSpecifiers { get; set; }
        public IdTypeProductionNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
			var helper = new GenerationHelper();
			var stringCode = "";
			stringCode += helper.GetFullNameFromIdNode(IdType);
            if (RankSpecifiers != null){
                foreach (var rank in RankSpecifiers)
                    stringCode += rank.GenerateCode().Code;
            }
            return new ExpressionCode { Code = "",Type=helper.GetFullNameFromIdNode(IdType) };
        }
    }
}
