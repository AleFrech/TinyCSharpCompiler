using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ParentesisExpresionNode : ExpressionNode
    {
        public  ExpressionNode ExpresioNode { get; set; }

        public AccesorExpressionNode AccesorExpression { get; set; }
    }
}
