using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationOrStatementNode : AssignationNodeStatement
    {
		public AssignationOrStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationOrStatementNode(){
            
        }

	}
}
