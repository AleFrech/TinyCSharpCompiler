using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationDivExpressionNode : AssignationExpressionNode
	{
		public AssignationDivExpressionNode(IdLeftExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}
