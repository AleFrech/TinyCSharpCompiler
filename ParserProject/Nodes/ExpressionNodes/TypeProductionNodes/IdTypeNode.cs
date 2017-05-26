using System;
namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class IdTypeNode:TypeProductionNode
    {
        public string Name { get; set; }
        public IdTypeNode IdNode { get; set; }

        public IdTypeNode(string name, IdTypeNode idtype )
        {
            Name = name;
            IdNode = idtype;
        }

        public IdTypeNode(){
            
        }
    }
}
