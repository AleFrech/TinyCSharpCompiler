using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationDivStatementNode : AssignationNodeStatement
    {
		public AssignationDivStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationDivStatementNode(){
            
        }
	}
}
