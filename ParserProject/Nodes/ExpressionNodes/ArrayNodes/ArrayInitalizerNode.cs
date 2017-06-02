using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class ArrayInitalizerNode:ExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
