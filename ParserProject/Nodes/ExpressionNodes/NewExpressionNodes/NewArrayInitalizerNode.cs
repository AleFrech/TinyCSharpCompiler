using System;
namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes
{
    public class NewArrayInitalizerNode:NewExpressionNode
    {
        public RankSpeciferNode RankSpecifer { get; set; }
        public NewArrayInitalizerNode()
        {
        }
    }
}
