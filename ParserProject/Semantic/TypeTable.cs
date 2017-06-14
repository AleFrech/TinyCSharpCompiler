using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Apis;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
using ParserProject.Nodes.NameSpaceNodes.EnumNodes;
using ParserProject.Nodes.NameSpaceNodes.InterfaceNodes;

namespace ParserProject.Semantic
{
    public static class TypeTable
    {
        public static Dictionary<string,NameSpaceDeclarationNode> TypeList = new Dictionary<string, NameSpaceDeclarationNode>();
        


        public static void FillTable(List<List<CodeNode>> treeList)
        {
            foreach (var tl in treeList)
            {
                foreach (var tree in tl)
                {
                    foreach (var code in tree.NameSpaceDeclarationList)
                    {
                        var nmespace = code as NameSpaceNode;
                        if (nmespace == null)
                        {
                            var @class = code as ClassNode;
                            if (@class != null)
                            {
                                TypeList.Add(@class.NameToken.Lexeme, @class);
                            }
                            var @enum = code as EnumNode;
                            if (@enum != null)
                            {
                                TypeList.Add(@enum.NameToken.Lexeme, @enum);
                            }
                            var @interface = code as InterfaceNode;
                            if (@interface != null)
                            {
                                TypeList.Add(@interface.NameToken.Lexeme, @interface);
                            }
                        }
                        else
                        {
                            var fullname = GetFullNameFromIdNode(nmespace.IdNode);
                            foreach (var c in nmespace.Code.NameSpaceDeclarationList)
                            {
                                var @class = c as ClassNode;
                                if (@class != null)
                                {
                                    TypeList.Add(fullname+"."+@class.NameToken.Lexeme, @class);
                                }
                                var @enum = c as EnumNode;
                                if (@enum != null)
                                {
                                    TypeList.Add(fullname + "." + @enum.NameToken.Lexeme, @enum);
                                }
                                var @interface = c as InterfaceNode;
                                if (@interface != null)
                                {
                                    TypeList.Add(fullname + "." + @interface.NameToken.Lexeme, @interface);
                                }
                            }                      
                        }
                    }
                }
            }
        }

        private static string GetFullNameFromIdNode(IdTypeNode idNode, string name = "")
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
