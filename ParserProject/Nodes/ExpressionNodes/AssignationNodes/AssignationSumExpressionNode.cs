using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationSumExpressionNode:AssignationExpressionNode
    {
        public AssignationSumExpressionNode(IdLeftExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }
    }
}
