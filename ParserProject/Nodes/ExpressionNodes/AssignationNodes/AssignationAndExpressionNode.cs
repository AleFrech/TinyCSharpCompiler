using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationAndExpressionNode : AssignationExpressionNode
	{
		public AssignationAndExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}
