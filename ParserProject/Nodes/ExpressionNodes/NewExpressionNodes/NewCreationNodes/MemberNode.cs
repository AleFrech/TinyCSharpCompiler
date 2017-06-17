using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
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
    }
}
