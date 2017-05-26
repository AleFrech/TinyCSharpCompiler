using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class InterfaceDeclarationNode:NameSpaceDeclarationNode
    {
        public PrivacyModifierNode PrivacyModifierNode { get; set; }
        public InterfaceStructureNode InterfaceStructure { get; set; }
    }
}
