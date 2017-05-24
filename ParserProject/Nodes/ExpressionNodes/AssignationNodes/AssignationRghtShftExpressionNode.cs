using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationRghtShftExpressionNode : AssignationExpressionNode
	{
		public AssignationRghtShftExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}
