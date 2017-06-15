using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public class PeriodAccessor : AccesorExpressionNode
    {
        public Token Id { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
