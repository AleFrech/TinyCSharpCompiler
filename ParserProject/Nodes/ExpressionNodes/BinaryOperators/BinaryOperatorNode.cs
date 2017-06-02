using System;
using System.Collections.Generic;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public abstract class BinaryOperatorNode : ExpressionNode
    {
		public Dictionary<Tuple<CustomType, CustomType>, CustomType> OperatorRules
			= new Dictionary<Tuple<CustomType, CustomType>, CustomType>();

		public ExpressionNode LeftOperand { get; set; }
        public ExpressionNode RightOperand { get; set; }

        public override CustomType EvaluateSemantic()
        {
            var leftType = LeftOperand.EvaluateSemantic();
            var rightType = RightOperand.EvaluateSemantic();

			var key = new Tuple<CustomType, CustomType>(leftType,rightType);
            if (!OperatorRules.ContainsKey(key))
                throw new SemanticException("Opperation Rule Not Supported");
            return OperatorRules[key];
        }
    }
}
