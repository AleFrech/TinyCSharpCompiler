using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes.CastExpresionNodes
{
    public class CastExpressionNode:PrimaryExpressionNode
    {
        public ExpressionNode Left { get; set; }

        public ExpressionNode Right { get; set; }
    }
}
