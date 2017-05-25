using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationExpressionNode : ExpressionNode
    {
        public IdLeftExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue {get;set;}

		public AssignationExpressionNode()
        {

        }
    }
}
