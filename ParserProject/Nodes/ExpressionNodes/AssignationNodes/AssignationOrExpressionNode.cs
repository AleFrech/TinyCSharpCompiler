using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationOrExpressionNode : AssignationExpressionNode
	{
		public AssignationOrExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationOrExpressionNode(){
            
        }

	}
}
