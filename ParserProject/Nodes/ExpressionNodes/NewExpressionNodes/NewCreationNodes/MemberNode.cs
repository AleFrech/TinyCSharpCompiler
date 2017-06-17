using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class MemberNode : ExpressionNode
    {
        public Token Name { get; set; }
        public ExpressionNode Expression { get; set; }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = Name.Lexeme + " ";
            if (Expression != null)
                stringCode += "= " + Expression.GenerateCode().Code;
            return new ExpressionCode{Code = stringCode};
        }
    }
}
