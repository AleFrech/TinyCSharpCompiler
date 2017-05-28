using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationAndStatementNode : AssignationNodeStatement
    {
		public AssignationAndStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationAndStatementNode(){
            
        }
	}
}
