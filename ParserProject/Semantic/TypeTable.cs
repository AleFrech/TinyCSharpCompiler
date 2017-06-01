using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Semantic
{
	public class TypesTable
	{
         readonly Dictionary<string, PrimitiveTypeNode> _table;
		 static TypesTable _instance;

		 TypesTable()
		{
			_table = new Dictionary<string, PrimitiveTypeNode>
            {
                {"int", new PrimitiveIntNode()},
                {"string", new PrimitiveStringNode()},
                {"float", new PrimitiveFloatNode()},
                {"char", new PrimitiveCharNode()},
                {"bool", new PrimitiveBoolNode()},
                {"enum", new PrimitiveEnumNode()},

			};
		}

		public static TypesTable Instance => _instance  ?? (_instance = new TypesTable());

		public void RegisterType(string name, PrimitiveTypeNode baseType, int row)
		{
			if (_table.ContainsKey(name))
			{
				throw new SemanticException($"Type: {name} doesn't exists in row: {row}");
			}

			_table.Add(name, baseType);
		}

		public PrimitiveTypeNode GetType(string name, int row)
		{
			if (_table.ContainsKey(name))
			{
				return _table[name];
			}

            throw new SemanticException($"Type: {name} doesn't exists in row: {row}");
		}

		public PrimitiveTypeNode GetType(string name)
		{
			if (_table.ContainsKey(name))
			{
				return _table[name];
			}

			throw new SemanticException($"Type: {name} doesn't exists.");
		}


		public bool Contains(string name)
		{
			return _table.ContainsKey(name);
		}
	}
}
