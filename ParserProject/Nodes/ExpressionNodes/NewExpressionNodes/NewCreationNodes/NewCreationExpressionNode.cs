using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class NewCreationExpressionNode:NewExpressionNode
    {
        public TypeProductionNode Type { get; set; }
        public NewCreationExpressionNode NewCreationNode { get; set; }
        public AccesorExpressionNode Accessor { get; set; }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }
    }
}
