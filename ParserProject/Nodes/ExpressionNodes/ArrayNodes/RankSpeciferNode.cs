using System;
using System.Collections.Generic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class RankSpeciferNode:ExpressionNode
    {
        public List<DimSeparatorNode> DimSeparatorList { get; set; }
        public RankSpeciferNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
