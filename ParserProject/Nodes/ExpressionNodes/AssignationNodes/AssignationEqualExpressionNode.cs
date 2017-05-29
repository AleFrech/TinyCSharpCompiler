using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationEqualExpressionNode : AssignationExpressionNode
    {
        public AssignationEqualExpressionNode(ExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationEqualExpressionNode(){
            
        }
    }
}
