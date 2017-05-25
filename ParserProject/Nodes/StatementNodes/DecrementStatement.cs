using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DecrementStatement:StatementNode
    {
        public PrimaryExpressionNode PrimaryNode { get; set; }
        public DecrementStatement()
        {
        }
    }
}
