using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationRghtShftExpressionNode : AssignationExpressionNode
	{
		public AssignationRghtShftExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationRghtShftExpressionNode(){
            
        }
	}
}
