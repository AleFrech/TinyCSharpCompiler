using System;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumDeclarationNode:NameSpaceDeclarationNode
    {
		public PrivacyModifierNode PrivacyModifierNode { get; set; }
        public EnumStructureNode EnumStructure { get; set; }
        public EnumDeclarationNode()
        {
        }
    }
}
