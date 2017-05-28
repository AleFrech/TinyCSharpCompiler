using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationXorStatementNode : AssignationStatementNode
    {
		public AssignationXorStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationXorStatementNode(){
            
        }
	}
}
