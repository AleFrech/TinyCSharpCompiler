using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class EndNodeStatement:StatementNode
    {
        public EndNodeStatement()
        {
        }

        public override void EvaluateSemantic()
        {
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = "; \n" };
        }
    }
}
