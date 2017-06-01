using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public abstract class BinaryOperatorNode : ExpressionNode
    {
		public Dictionary<Tuple<PrimitiveTypeNode, PrimitiveTypeNode>, PrimitiveTypeNode> OperatorRules
			= new Dictionary<Tuple<PrimitiveTypeNode, PrimitiveTypeNode>, PrimitiveTypeNode>();

		public ExpressionNode LeftOperand { get; set; }
        public ExpressionNode RightOperand { get; set; }
    }
}
