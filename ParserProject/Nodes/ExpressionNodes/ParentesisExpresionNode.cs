using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ParentesisExpresionNode : ExpressionNode
    {
        public  ExpressionNode ExpresioNode { get; set; }

        public AccesorExpressionNode AccesorExpression { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
