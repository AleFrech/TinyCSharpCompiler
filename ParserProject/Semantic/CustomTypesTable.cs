using System;
using System.Collections.Generic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Semantic
{
	public class CustomTypesTable
	{
        readonly Dictionary<string, CustomType> _table;
		 static CustomTypesTable _instance;

		 CustomTypesTable()
		{
			_table = new Dictionary<string, CustomType>
            {
                {"Int", new IntType()},
                {"String", new StringType()},
                {"Float", new FloatType()},
                {"Char", new CharType()},
                {"Bool", new BoolType()},
                {"Enum", new EnumType()},
                {"Void", new VoidType()},

			};
		}

		public static CustomTypesTable Instance => _instance  ?? (_instance = new CustomTypesTable());

		public void AddType(string name, CustomType baseType)
		{
			if (_table.ContainsKey(name))
			{
				throw new SemanticException($"Type: {name} already exists");
			}

			_table.Add(name, baseType);
		}


		public CustomType GetType(string name)
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
