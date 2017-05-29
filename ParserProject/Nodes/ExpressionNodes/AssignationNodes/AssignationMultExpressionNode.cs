using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationMultExpressionNode : AssignationExpressionNode
    {
		public AssignationMultExpressionNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationMultExpressionNode(){
            
        }
    }

}
