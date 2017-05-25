using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationRghtShftExpressionNode : AssignationExpressionNode
	{
		public AssignationRghtShftExpressionNode(IdLeftExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}
