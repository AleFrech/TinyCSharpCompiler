using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationExpressionNode : ExpressionNode
    {
        public Dictionary<Tuple<CustomType, CustomType>, CustomType> OperatorRules
            = new Dictionary<Tuple<CustomType, CustomType>, CustomType>();
        public ExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue {get;set;}

		public AssignationExpressionNode()
        {

        }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

		public override ExpressionCode GenerateCode()
		{
            return new ExpressionCode { Code = LeftValue.GenerateCode().Code,Type = LeftValue.GenerateCode().Type};
		}
    }
}
