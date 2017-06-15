﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using LexerProject;
using ParserProject;
using ParserProject.Nodes.NameSpaceNodes;

namespace Compiler
{
    public class FileManager
    {
        private string systemClasses;
        public FileManager()
        {
            this.systemClasses  = @"namespace System {
                    public class Object{
                        
                        public virtual string ToString(){
                                return """";
                       }
                    }
                    public class int {
                        public static int Parse(){
                            return 1;    
                        }
                    }
                     public class float {
                        public static float Parse(){
                            return 0.5f;    
                        }
                    }
                   public class string {

                    }
                    public class Console {
                        public static WriteLine(){

                        }

                        public static ReadLine(){

                        }
                    }
                }";

        }

        public string GetSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
        }




        public List<List<CodeNode>> GetTreeListFromFiles()
        {
            var files = Directory.GetFiles("./TestProject", "*.cs", SearchOption.AllDirectories);
            var treeList= new List<List<CodeNode>>();
            foreach (var file in files)
            {
                
                var lex = new Lexer(new InputString(File.ReadAllText(file)));
                var parser = new Parser(lex);
                var tree = parser.Parse();
                treeList.Add(tree);
                
            }

            treeList.Add(new Parser(new Lexer(new InputString(systemClasses))).Parse());

            return treeList;
        }


        public void WriteXml(List<CodeNode> tree){
			const string assemblyName = "ParserProject";
			var types = Assembly.Load(new AssemblyName(assemblyName))
								.GetTypes().Where(type => type.GetTypeInfo().IsPublic)
								.Where(type => !type.Name.EndsWith("TokenTypeExtensions", StringComparison.Ordinal) &&
									   !type.Name.EndsWith("SintacticalException", StringComparison.Ordinal));
            
			XmlSerializer serialializer = new XmlSerializer(tree.GetType(), types.ToArray());

			StreamWriter writer = new StreamWriter(File.Create(Path.Combine(AppContext.BaseDirectory.
																		  Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/output.xml")));
			serialializer.Serialize(writer, tree);
        }
    }
}
