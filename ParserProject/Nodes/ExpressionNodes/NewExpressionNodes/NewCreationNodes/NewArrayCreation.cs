using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
	public class NewArrayCreation : NewExpressionNode
	{
		public BracketAccessor Bracket { get; set; }
		public List<RankSpeciferNode> RankSpecifiers { get; set; }
		public ArrayInitalizerNode ArrayInitalizer { get; set; }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            if (ArrayInitalizer != null)
                return new ExpressionCode { Code = ArrayInitalizer.GenerateCode().Code };
            return new ExpressionCode { Code = "[]" };
        }
    }
}
