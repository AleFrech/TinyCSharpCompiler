using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AccesorNodes
{
    public class BracketAccessor:AccesorExpressionNode
    {
        public List<ExpressionNode> expresionList { get; set; }

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
