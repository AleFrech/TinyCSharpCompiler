using System;
using System.Collections.Generic;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class RankSpeciferNode:ExpressionNode
    {
        public List<DimSeparatorNode> DimSeparatorList { get; set; }
        public RankSpeciferNode()
        {
        }
    }
}
