using System;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Generation
{
    public class GenerationHelper
    {
        public GenerationHelper()
        {
        }


		public string GetFullNameFromIdNode(IdTypeNode idNode, string name = "")
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


        public string GetFullAccessorFromAccessorNode(AccesorExpressionNode accessorNode, string accessorlist = "")
        {
            if (accessorNode == null)
                return accessorlist;

            var accumulatedAccessor = "";

            if (accessorNode is PeriodAccessor)
            {
                accumulatedAccessor += "." + ((PeriodAccessor)accessorNode).Id.Lexeme;
                return GetFullAccessorFromAccessorNode(accessorNode.Accessor, accumulatedAccessor);
            }
            else if (accessorNode is BracketAccessor)
            {

                accumulatedAccessor += "[";
                for (int i = 0; i < ((BracketAccessor)accessorNode).expresionList.Count; i++)
                {
                    if (((BracketAccessor)accessorNode).expresionList[i] == ((BracketAccessor)accessorNode).expresionList[((BracketAccessor)accessorNode).expresionList.Count - 1])
                    {
                        accumulatedAccessor += ((BracketAccessor)accessorNode).expresionList[i].GenerateCode();
                    }
                    else
                    {
                        accumulatedAccessor += ((BracketAccessor)accessorNode).expresionList[i].GenerateCode();
                        accumulatedAccessor += ",";
                    }
                }
                accumulatedAccessor += "]";
                return GetFullAccessorFromAccessorNode(accessorNode.Accessor, accumulatedAccessor);

            }
            else if (accessorNode is ParentesisAccessor){
				accumulatedAccessor += "(";
				for (int i = 0; i < ((ParentesisAccessor)accessorNode).expresionList.Count; i++)
				{
					if (((ParentesisAccessor)accessorNode).expresionList[i] == ((ParentesisAccessor)accessorNode).expresionList[((BracketAccessor)accessorNode).expresionList.Count - 1])
					{
						accumulatedAccessor += ((ParentesisAccessor)accessorNode).expresionList[i].GenerateCode();
					}
					else
					{
						accumulatedAccessor += ((ParentesisAccessor)accessorNode).expresionList[i].GenerateCode();
						accumulatedAccessor += ",";
					}
				}
                accumulatedAccessor += ")";
                return GetFullAccessorFromAccessorNode(accessorNode.Accessor, accumulatedAccessor);
            }else{
                throw new GenerationException("Cannot generate invalid accessor");
            }

        }

    }
}
