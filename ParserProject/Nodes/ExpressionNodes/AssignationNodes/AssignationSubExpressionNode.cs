using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
    public class AssignationSubExpressionNode : AssignationExpressionNode
    {
        public AssignationSubExpressionNode(ExpressionNode left, ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationSubExpressionNode(){
            
        }
    }
}
