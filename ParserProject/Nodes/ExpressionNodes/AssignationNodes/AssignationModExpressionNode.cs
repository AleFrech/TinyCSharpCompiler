using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationModExpressionNode : AssignationExpressionNode
	{
		public AssignationModExpressionNode(IdLeftExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}

}
