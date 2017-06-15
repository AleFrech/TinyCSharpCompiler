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
            var leftType = LeftValue.EvaluateSemantic();
            var rightType = LeftValue.EvaluateSemantic();

            if (leftType.GetType() != rightType.GetType())
                throw new SemanticException($"Opperation Rule Not Supported  between {leftType} and {rightType}");
            return leftType;
        }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
