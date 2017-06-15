using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class RankSpeciferNode:ExpressionNode
    {
        public List<string> DimSeparatorList { get; set; }
        public RankSpeciferNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = GetDimensionalArray(0, DimSeparatorList.Count) };
        }

        private string GetDimensionalArray(int length,int max){
            var str = "[ ";
	        if (length < max)
				str += GetDimensionalArray(length + 1, max);
            str += " ]";
            return str;
        }
    }
}
