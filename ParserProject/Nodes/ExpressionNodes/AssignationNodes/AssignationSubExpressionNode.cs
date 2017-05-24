using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationSubExpressionNode:AssignationExpressionNode
    {
		public AssignationSubExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
    }
}
