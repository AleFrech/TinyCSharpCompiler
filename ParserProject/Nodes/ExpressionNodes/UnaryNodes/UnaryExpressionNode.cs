using System;
using LexerProject.Tokens;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class UnaryExpressionNode:ExpressionNode
    {
        public Token Value { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }





}
