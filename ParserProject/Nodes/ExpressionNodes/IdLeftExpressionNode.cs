using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PreIdNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdLeftExpressionNode : PrimaryExpressionNode
    {
        public PreIdExpressionNode PreId { get; set; }
        public string Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }


        public IdLeftExpressionNode(PreIdExpressionNode preId, string name,AccesorExpressionNode accesor)
        {
            PreId = preId;
            Name = name;
            Accessor = accesor;
        }

    }
}