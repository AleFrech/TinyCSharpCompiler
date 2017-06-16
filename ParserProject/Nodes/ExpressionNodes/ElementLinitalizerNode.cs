using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Generation;
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

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "{ ";
            if (ExpressionList != null)
            {
                for (int i = 0; i < ExpressionList.Count; i++)
                {
                    if (ExpressionList[i] == ExpressionList[ExpressionList.Count - 1])
                        stringCode += ExpressionList[i].GenerateCode().Code;
                    else
                        stringCode += ExpressionList[i].GenerateCode().Code + ",";
                }
            }
            stringCode += " }";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
