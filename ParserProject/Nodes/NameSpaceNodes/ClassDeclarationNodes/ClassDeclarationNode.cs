using System;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
	public class ClassDeclarationNode : NameSpaceDeclarationNode
	{
	    public PrivacyModifierNode PrivacyModifierNode { get; set; }

	    public ClassStructureNode ClassStructure { get; set; }
	}
}
