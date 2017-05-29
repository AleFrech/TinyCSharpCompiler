using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationModExpressionNode : AssignationExpressionNode
	{
		public AssignationModExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationModExpressionNode(){
            
        }
	}

}
