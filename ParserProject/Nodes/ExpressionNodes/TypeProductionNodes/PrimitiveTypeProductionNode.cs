using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
	public class PrimitiveTypeProductionNode : TypeProductionNode
	{
		public PrimitiveTypeNode primitiveType { get; set; }
        public List<RankSpeciferNode> rankSpecifiers { get; set; }
	}
}
