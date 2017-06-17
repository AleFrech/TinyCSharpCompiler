using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes
{
    public class NewArrayInitalizerNode:NewExpressionNode
    {
        public RankSpeciferNode RankSpecifer { get; set; }

        public ArrayInitalizerNode ArrayInitalizerNode { get; set; }

        public NewArrayInitalizerNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode{Code = ArrayInitalizerNode.GenerateCode().Code};
        }
    }
}
