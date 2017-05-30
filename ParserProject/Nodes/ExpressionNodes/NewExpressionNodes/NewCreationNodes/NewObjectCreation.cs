using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class NewObjectCreation:NewCreationExpressionNode
    {
        public List<ExpressionNode> ObjectCollectionInitalizer { get; set; }

        public List<ExpressionNode> ObjectArgumentsList { get; set; }
    }
}
