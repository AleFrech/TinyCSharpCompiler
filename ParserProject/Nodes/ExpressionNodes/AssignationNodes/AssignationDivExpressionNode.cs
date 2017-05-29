using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationDivExpressionNode : AssignationExpressionNode
	{
		public AssignationDivExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationDivExpressionNode(){
            
        }
	}
}
