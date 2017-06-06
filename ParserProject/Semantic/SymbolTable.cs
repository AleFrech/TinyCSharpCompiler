using System;
using System.Collections.Generic;
using System.Linq;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Semantic
{
	public static class SymbolTable
	{
		public  static readonly List<Context> ContextList = new List<Context>();
		
		
		public static void CreateContext()
		{
		    ContextList.Insert(0, new Context());
		}

		public static void RemoveContext()
		{
		    ContextList.RemoveAt(0);
		}
	}
}
