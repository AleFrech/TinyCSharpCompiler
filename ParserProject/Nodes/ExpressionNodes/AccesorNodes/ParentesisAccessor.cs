using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public class ParentesisAccessor:AccesorExpressionNode
    {
        public List<ExpressionNode> expresionList { get; set; }
        public ParentesisAccessor()
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
