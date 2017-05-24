using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationEqualExpressionNode:AssignationExpressionNode
    {
        public AssignationEqualExpressionNode(IdExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }
    }
}
