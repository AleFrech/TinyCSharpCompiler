using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationXorExpressionNode : AssignationExpressionNode
	{
		public AssignationXorExpressionNode(IdLeftExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationXorExpressionNode(){
            
        }
	}
}
