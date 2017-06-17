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
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "." + Id.Lexeme;
            if(Accessor!=null){
                stringCode += Accessor.GenerateCode().Code;
            }
            return new ExpressionCode { Code = stringCode };
        }
    }
}
