using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class IdTypeProductionNode:TypeProductionNode
    {
        public IdTypeNode IdType { get; set; }
		public List<RankSpeciferNode> rankSpecifiers { get; set; }
        public IdTypeProductionNode()
        {
        }
    }
}
