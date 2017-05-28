using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationMultStatemntNode: AssignationNodeStatement
    {
		public AssignationMultStatemntNode(ExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}

        public AssignationMultStatemntNode(){
            
        }
    }

}
