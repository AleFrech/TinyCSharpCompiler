using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationSumStatementNode: AssignationNodeStatement
    {
        public AssignationSumStatementNode(ExpressionNode left,ExpressionNode right)
        {
            LeftValue = left;
            RightValue = right;
        }

        public AssignationSumStatementNode(){
            
        }
    }
}
