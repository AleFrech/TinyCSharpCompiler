using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class IncrementStatement : StatementNode
	{
		public ExpressionNode ExpressionNode { get; set; }
		public IncrementStatement()
		{
		}
	}
}
