using System.Collections.Generic;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassBodyNode
    {
        public  List<FieldMethodConstructor> ClassMemberDeclarationList { get; set; }
    }
}
