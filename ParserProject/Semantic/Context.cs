using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Semantic
{
    public class Context
    {
        private readonly Dictionary<string, CustomType> _variables;

        public Context()
        {
            _variables = new Dictionary<string, CustomType>();
        }


        public void AddVaraible(Token name,CustomType type)
        {
            if(!_variables.ContainsKey(name.Lexeme))
                _variables.Add(name.Lexeme,type);
            throw new SemanticException($"Variable: {name.Lexeme} already exists.");
        }

        public CustomType GetVariable(Token name)
        {
            if(!_variables.ContainsKey(name.Lexeme))
                throw new Exception($"Variable: {name.Lexeme} doesn't exists.");
            return _variables[name.Lexeme];
        }

        public bool VariableExist(Token name)
        {
            return _variables.ContainsKey(name.Lexeme);
        }



    }
}
