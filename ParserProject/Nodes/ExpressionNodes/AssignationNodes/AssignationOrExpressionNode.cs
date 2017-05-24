using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationOrExpressionNode : AssignationExpressionNode
	{
		public AssignationOrExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}
