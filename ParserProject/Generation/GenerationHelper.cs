using System;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Generation
{
	public class GenerationHelper
	{
		public GenerationHelper()
		{
		}


		public string GetFullNameFromIdNode(IdTypeNode idNode, string name = "")
		{
			if (idNode == null)
			{
				return name;
			}
			var accumulated = name;
			if (!String.IsNullOrEmpty(name))
				accumulated += ".";
			accumulated += idNode.Name.Lexeme;
			return GetFullNameFromIdNode(idNode.IdNode, accumulated);
		}
	}
}