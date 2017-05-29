using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationLftShftExpressionNode : AssignationExpressionNode
	{
		public AssignationLftShftExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationLftShftExpressionNode(){
            
        }
	}
}
