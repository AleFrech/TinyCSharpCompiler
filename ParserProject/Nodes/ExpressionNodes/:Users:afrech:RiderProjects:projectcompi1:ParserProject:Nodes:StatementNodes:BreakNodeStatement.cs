using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class BreakNodeStatement:StatementNode
    {
        public BreakNodeStatement()
        {
        }

        public override void EvaluateSemantic()
        {
            throw new NotImplementedException();
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = "break;" };
        }
    }
}
