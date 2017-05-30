using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
	public class NewArrayCreation : NewCreationExpressionNode
	{
		public BracketAccessor Bracket { get; set; }
		public List<RankSpeciferNode> RankSpecifiers { get; set; }
		public ArrayInitalizerNode ArrayInitalizer { get; set; }
	}
}
