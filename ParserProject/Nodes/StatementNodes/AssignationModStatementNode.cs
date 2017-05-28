using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationModStatementNode : AssignationNodeStatement
    {
		public AssignationModStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationModStatementNode(){
            
        }
	}

}
