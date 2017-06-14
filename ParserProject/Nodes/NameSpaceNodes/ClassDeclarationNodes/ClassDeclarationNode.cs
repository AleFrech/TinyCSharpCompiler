using System;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
	public class ClassDeclarationNode : NameSpaceDeclarationNode
	{
	    public string PrivacyModifierNode { get; set; }

	    public ClassStructureNode ClassStructure { get; set; }
	}
}
