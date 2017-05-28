using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PreIdNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdLeftExpressionNode : PrimaryExpressionNode
    {
        public PreIdExpressionNode PreId { get; set; }
        public IdTypeNode Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }


        public IdLeftExpressionNode(PreIdExpressionNode preId, IdTypeNode name,AccesorExpressionNode accesor)
        {
            PreId = preId;
            Name = name;
            Accessor = accesor;
        }

        public IdLeftExpressionNode(){
            
        }

    }
}