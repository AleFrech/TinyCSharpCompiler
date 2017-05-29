using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationAndExpressionNode : AssignationExpressionNode
	{
		public AssignationAndExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationAndExpressionNode(){
            
        }
	}
}
