using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ElementLinitalizerNode:ExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
