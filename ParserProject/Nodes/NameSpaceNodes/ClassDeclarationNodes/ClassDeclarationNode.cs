using System;
using ParserProject.Generation;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
	public class ClassDeclarationNode : NameSpaceDeclarationNode
	{
	    public string PrivacyModifierNode { get; set; }

	    public ClassStructureNode ClassStructure { get; set; }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
