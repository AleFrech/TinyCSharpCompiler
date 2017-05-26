using ParserProject.Nodes.ExtendsNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class InterfaceStructureNode
    {
        public string Name { get; set; }
        public ExtendsNode  ExtendsNode { get; set; }

        public InterfaceStructureNode(string idlexeme, ExtendsNode extendsNode)
        {
            Name = idlexeme;
            ExtendsNode = extendsNode;
        }
    }
}