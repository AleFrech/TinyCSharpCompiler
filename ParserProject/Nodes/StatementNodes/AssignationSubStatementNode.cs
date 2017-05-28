using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationSubStatementNode : AssignationNodeStatement
    {
        public AssignationSubStatementNode(ExpressionNode left, ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationSubStatementNode(){
            
        }
    }
}
