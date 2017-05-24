using System;
using System.Collections.Generic;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public class ParentesisAccessor:AccesorExpressionNode
    {
        public List<ExpressionNode> expresionList { get; set; }
        public ParentesisAccessor()
        {
        }
    }
}
