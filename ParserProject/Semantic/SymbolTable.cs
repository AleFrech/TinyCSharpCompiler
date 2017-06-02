using System;
using System.Collections.Generic;
using System.Linq;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Semantic
{
	public class SymbolTable
	{
		private static readonly List<SymbolTable> _instance = new List<SymbolTable>();
		private readonly Dictionary<string, CustomType> _variables;
		
		//private readonly Dictionary<string, Value> _values;

		public SymbolTable()
		{
			_variables = new Dictionary<string, CustomType>();
			//_values = new Dictionary<string, Value>();
		}

		public static SymbolTable Instance
		{
			get
			{
				if (_instance.Count == 0)
				{
					_instance.Add(new SymbolTable());
				}

				return _instance[0];
			}
		}

		//public void DeclareVariable(string name, CustomType type)
		//{
		//	_variables.Add(name, type);
		//	_values.Add(name, type.GetDefaultValue());
		//}

		public CustomType GetVariable(string name)
		{
			foreach (var symbolTable in _instance)
			{
				if (symbolTable._variables.ContainsKey(name))
					return symbolTable._variables[name];
			}

			throw new Exception($"Variable: {name} doesn't exists.");
		}

		public bool VariableExist(string name)
		{
			return _instance.Any(symbolTable => symbolTable._variables.ContainsKey(name));
		}

		public static void CreateContext()
		{
			_instance.Insert(0, new SymbolTable());
		}

		public static void RemoveContext()
		{
			_instance.RemoveAt(0);
		}

		
		//public void SetVariableValue(string name, Value interpret)
		//{
		//	foreach (var symbolTable in _instance)
		//	{
		//		if (symbolTable._variables.ContainsKey(name))
		//			symbolTable._values[name] = interpret;
		//	}

		//}
          
	}
}
