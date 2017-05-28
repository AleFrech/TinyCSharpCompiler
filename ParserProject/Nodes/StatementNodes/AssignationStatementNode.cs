using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationStatementNode : StatementNode
    {
        public ExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue {get;set;}

		public AssignationStatementNode()
        {

        }
    }
}
