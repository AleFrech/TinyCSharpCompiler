using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationSumExpressionNode : AssignationExpressionNode
    {
        public AssignationSumExpressionNode(ExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationSumExpressionNode(){
            
        }
    }
}
