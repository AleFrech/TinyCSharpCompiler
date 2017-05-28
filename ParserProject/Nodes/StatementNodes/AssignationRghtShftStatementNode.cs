using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
	public class AssignationRghtShftStatementNode : AssignationNodeStatement
    {
		public AssignationRghtShftStatementNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationRghtShftStatementNode(){
            
        }
	}
}
