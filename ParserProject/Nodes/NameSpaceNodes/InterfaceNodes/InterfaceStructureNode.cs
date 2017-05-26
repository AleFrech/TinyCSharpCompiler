using ParserProject.Nodes.ExtendsNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceStructureNode
    {
        public string Name { get; set; }
        public ExtendsNode  ExtendsNode { get; set; }
        public InterfaceBodyNode InterfaceBody { get; set; }

        public InterfaceStructureNode(string idlexeme, ExtendsNode extendsNode , InterfaceBodyNode interfaceBody)
        {
            Name = idlexeme;
            ExtendsNode = extendsNode;
            InterfaceBody = interfaceBody;
        }

        public InterfaceStructureNode(){
            
        }
    }
}