using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationSumExpressionNode:AssignationExpressionNode
    {
        public AssignationSumExpressionNode(IdExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }
    }
}
