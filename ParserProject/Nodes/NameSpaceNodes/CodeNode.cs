using System;
using System.Collections.Generic;
using ParserProject.Generation;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public  class CodeNode
    {
        public List<UsingDirectiveNode> UsingDirectiveList { get; set; }
        public List<NameSpaceDeclarationNode> NameSpaceDeclarationList { get; set; }
        public CodeNode()
        {
        }

		public  ExpressionCode GenerateCode()
		{
            var stringCode = "";
            foreach(var us in UsingDirectiveList){
                stringCode+="require "+us.GenerateCode().Code+"\n";
            }
			foreach (var @namespace in NameSpaceDeclarationList)
			{
				stringCode += @namespace.GenerateCode().Code + "\n";
			}
            return new ExpressionCode { Code = stringCode };
		}
    }
}
