using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using ParserProject.Nodes.NameSpaceNodes;

namespace Compiler
{
    public class FileManager
    {

        public string GetSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
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
