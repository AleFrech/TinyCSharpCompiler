using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceDeclarationNode:NameSpaceDeclarationNode
    {
        public PrivacyModifierNode PrivacyModifierNode { get; set; }
        public InterfaceStructureNode InterfaceStructure { get; set; }
    }
}
