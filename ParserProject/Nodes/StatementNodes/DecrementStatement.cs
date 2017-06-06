using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class DecrementStatement:StatementNode
    {
        public ExpressionNode ExpressionNode { get; set; }
        public DecrementStatement()
        {
        }

        public override void EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
