
namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumDeclarationNode:NameSpaceDeclarationNode
    {
		public string PrivacyModifierNode { get; set; }
        public EnumStructureNode EnumStructure { get; set; }
        public EnumDeclarationNode()
        {
        }
    }
}
