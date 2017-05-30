using LexerProject.Tokens;
using ParserProject.Nodes.ExtendsNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceStructureNode
    {
        public Token Name { get; set; }
        public ExtendsNode  ExtendsNode { get; set; }
        public InterfaceBodyNode InterfaceBody { get; set; }

        public InterfaceStructureNode(Token idlexeme, ExtendsNode extendsNode , InterfaceBodyNode interfaceBody)
        {
            Name = idlexeme;
            ExtendsNode = extendsNode;
            InterfaceBody = interfaceBody;
        }

        public InterfaceStructureNode(){
            
        }
    }
}