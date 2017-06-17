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
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
			var stringCode = "(";
			if (expresionList != null)
			{
				for (int i = 0; i < expresionList.Count; i++)
				{
					if (expresionList[i] == expresionList[expresionList.Count - 1])
						stringCode += expresionList[i].GenerateCode().Code;
					else
						stringCode += expresionList[i].GenerateCode().Code + ",";
				}
			}
            stringCode += ")";
            if(Accessor!=null){
                stringCode += Accessor.GenerateCode().Code;
            }
			return new ExpressionCode { Code = stringCode };
        }
    }
}
