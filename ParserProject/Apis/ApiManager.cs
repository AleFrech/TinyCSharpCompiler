using System;
using System.Collections.Generic;
using System.Linq;
using ParserProject.Exceptions;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;

namespace ParserProject.Apis
{
    public class ApiManager
    {
        private readonly List<CodeNode> _tree;
        public ApiManager(List<CodeNode> tree)
        {
            _tree = tree;
        }

        public NameSpaceNode GetNameSpace(string name)
        {
            foreach (var ns in _tree.SelectMany(x=>x.NameSpaceDeclarationList))
            {
                var namespaceNode = (NameSpaceNode) ns;
                var nameSpaceFullName = GetFullNameFromIdNode(namespaceNode.IdNode);
                if (nameSpaceFullName == name)
                {
                    return namespaceNode;
                }
            }
            throw new NameSpaceNotFoundExcpetion("Namespace "+name+ " Not Found" );
        }

        public ClassDeclarationNode GetClass(string name)
        {
            if (!name.Contains("."))
            {
                foreach (var ns in _tree.SelectMany(x => x.NameSpaceDeclarationList))
                {
                    var @class = ns as ClassDeclarationNode;
                    if (@class != null)
                    {
                        if (@class.ClassStructure.Name.Lexeme == name)
                            return @class;
                    }  
                }
                throw new ClassNotFoundExcpetion("Class " + name + " Not Found");
            }

            var list = name.Split('.');
            var className = list.Last();
            var namespaceName=list[0];
            for (int i = 1; i < list.Length-1; i++)
            {
                namespaceName += "."+list[i];
            }
            var @namespace = GetNameSpace(namespaceName);
            foreach (var ns in @namespace.Code.NameSpaceDeclarationList)
            {
                var @class = (ClassDeclarationNode)ns;
                if (@class.ClassStructure.Name.Lexeme== className)
                    return @class;
            }
            throw new ClassNotFoundExcpetion("Class " + name + " Not Found");
        }

        private string GetFullNameFromIdNode(IdTypeNode idNode, string name="")
        {
            if (idNode == null)
            {
                return name;
            }
            var accumulated = name;
            if (!String.IsNullOrEmpty(name))
                accumulated += ".";
            accumulated += idNode.Name.Lexeme;
            return GetFullNameFromIdNode(idNode.IdNode, accumulated);
        }



    }
}
