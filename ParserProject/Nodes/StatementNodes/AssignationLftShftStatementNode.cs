using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationLftShftStatementNode : AssignationNodeStatement
    {
		public AssignationLftShftStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationLftShftStatementNode(){
            
        }
	}
}
