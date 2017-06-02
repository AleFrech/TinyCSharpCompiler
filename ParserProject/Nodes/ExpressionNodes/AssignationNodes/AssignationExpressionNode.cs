using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationExpressionNode : ExpressionNode
    {
        public ExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue {get;set;}

		public AssignationExpressionNode()
        {

        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
