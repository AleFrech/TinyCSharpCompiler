using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimaryExpressionNode:ExpressionNode
    {
        public PrimaryExpressionNode()
        {
            
        }

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
