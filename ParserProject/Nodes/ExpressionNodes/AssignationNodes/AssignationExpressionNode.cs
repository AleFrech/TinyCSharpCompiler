using System;
using System.Collections.Generic;
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

            var key = new Tuple<CustomType, CustomType>(leftType, rightType);
            if (!OperatorRules.ContainsKey(key))
                throw new SemanticException($"Opperation Rule Not Supported  between {leftType} and {rightType}");
            return OperatorRules[key];
        }
    }
}
