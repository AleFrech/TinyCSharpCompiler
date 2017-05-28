using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationEqualStatementNode: AssignationNodeStatement
    {
        public AssignationEqualStatementNode(ExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationEqualStatementNode(){
            
        }
    }
}
