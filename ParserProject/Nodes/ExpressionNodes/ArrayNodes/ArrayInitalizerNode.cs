using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Generation;
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

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "[";
            if (ExpressionList != null)
                foreach (var exp in ExpressionList)
                    stringCode += exp.GenerateCode().Code;
            stringCode += "]";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
