

using System;
using ParserProject.Generation;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceDeclarationNode : NameSpaceDeclarationNode
    {
        public string PrivacyModifierNode { get; set; }
        public InterfaceStructureNode InterfaceStructure { get; set; }

        public  InterfaceDeclarationNode(){
            
        }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
