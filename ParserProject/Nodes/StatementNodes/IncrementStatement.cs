using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class IncrementStatement : StatementNode
	{
		public PrimaryExpressionNode PrimaryNode { get; set; }
		public IncrementStatement()
		{
		}
	}
}
