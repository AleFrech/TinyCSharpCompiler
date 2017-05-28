using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DecrementStatement:StatementNode
    {
        public ExpressionNode ExpressionNode { get; set; }
        public DecrementStatement()
        {
        }
    }
}
