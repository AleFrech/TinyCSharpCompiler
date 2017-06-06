using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.NameSpaceNodes.MethodModiferNodes
{
    public class AbstractMethodModifer:MethodModifierNode
    {
        public AbstractMethodModifer(){
            Value = "abstract";
        }
    }
}
