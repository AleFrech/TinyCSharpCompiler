using System;
using LexerProject;
using LexerProject.Tokens;
using ParserProject.Exceptions;
using ParserProject.Extensions;

namespace ParserProject
{
      public class Parser
      {
         private readonly Lexer _lexer;
         private Token _currentToken;

         public Parser(Lexer lexer)
         {
            _lexer = lexer;
            _currentToken = _lexer.GetNextToken();
         }

         public void Parse()
         {
            Code();
            if (_currentToken.Type != TokenType.Eof)
               throw new SintacticalException("Expected Eof");
         }

         private void Code()
         {
            NameSpaceList();
         }

         private void NameSpaceList()
         {
            if (_currentToken.Type.IsNameSpace())
            {
               NameSpace();
               NameSpaceList();
            }
            else
            {

            }

         }

         private void NameSpace()
         {
            UsingDirectives();
            NameSpaceDeclarations();
         }

         private void UsingDirectives()
         {
            if (_currentToken.Type == TokenType.RwUsing)
            {
               UsingDirective();
               UsingDirectives();
            }
            else
            {

            }
         }

         private void UsingDirective()
         {
            if (_currentToken.Type != TokenType.RwUsing)
               throw new SintacticalException("Expected using Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            TypeName();
            if (_currentToken.Type != TokenType.EndStatement)
               throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " + _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void TypeName()
         {
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            TypeNamePrime();
         }

         private void TypeNamePrime()
         {
            if (_currentToken.Type == TokenType.Period)
            {
               _currentToken = _lexer.GetNextToken();
               if (_currentToken.Type != TokenType.Id)
                  throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
               TypeNamePrime();
            }
            else
            {

            }
         }

         private void NameSpaceDeclarations()
         {
            if (_currentToken.Type.IsPrivacyModifier() || _currentToken.Type == TokenType.RwNamespace)
            {
               NameSpaceDeclaration();
               NameSpaceDeclarations();
            }
            else
            {

            }
         }

         private void NameSpaceDeclaration()
         {
            if (_currentToken.Type == TokenType.RwNamespace)
            {
               NameSpaceStatement();
            }
            else
            {
               PrivacyModifier();
               ClassInterfaceEnum();
            }

         }

         private void PrivacyModifier()
         {
            if (_currentToken.Type.IsPrivacyModifier())
               _currentToken = _lexer.GetNextToken();
            else
            {

            }
         }

         private void NameSpaceStatement()
         {
            if (_currentToken.Type != TokenType.RwNamespace)
               throw new SintacticalException("Expected Namespace Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            TypeName();
            NameSpaceBody();

         }

         private void NameSpaceBody()
         {
            if (_currentToken.Type != TokenType.KeyOpen)
               throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            NameSpace();
            if (_currentToken.Type != TokenType.KeyClose)
               throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void ClassInterfaceEnum()
         {
            if (_currentToken.Type == TokenType.RwInterface)
              InterfaceDeclaration();
            else if (_currentToken.Type == TokenType.RwEnum)
               EnumDeclaration();
            else
               ClassDeclaration();
         }

         private void InterfaceDeclaration()
         {
            if (_currentToken.Type != TokenType.RwInterface)
               throw new SintacticalException("Expected interface Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            Heredance();
            InterfaceBody();
         }

         private void InterfaceBody()
         {
            if (_currentToken.Type != TokenType.KeyOpen)
               throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            InterfaceMemberDeclarations();
            if (_currentToken.Type != TokenType.KeyClose)
               throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void InterfaceMemberDeclarations()
         {
            if (_currentToken.Type.IsType() || _currentToken.Type == TokenType.RwVoid)
            {
               InterfaceElement();
               InterfaceMemberDeclarations();
            }
            else
            {

            }
         }

         private void InterfaceElement()
         {
            if (_currentToken.Type.IsType())
            {
               TypeProduction();
               if (_currentToken.Type != TokenType.Id)
                  throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
               MethodProperty();
            }else if (_currentToken.Type == TokenType.RwVoid)
            {
               _currentToken = _lexer.GetNextToken();
               if (_currentToken.Type != TokenType.Id)
                  throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
               MethodProperty();
            }
         }

         private void MethodProperty()
         {
            if (_currentToken.Type == TokenType.ParOpen)
            {
               MethodHeader();
                if (_currentToken.Type != TokenType.EndStatement)
                  throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
            }else if (_currentToken.Type == TokenType.KeyOpen)
            {
               PropertyDeclaration();
            }
         }

         private void PropertyDeclaration()
         {
            if (_currentToken.Type != TokenType.KeyOpen)
               throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            PropertyAcccesors();
            if (_currentToken.Type != TokenType.KeyClose)
               throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void PropertyAcccesors()
         {
            PropertyAcccesorsPrivacyModifiers();
            PropertyAcccesorsBody();
         }

         private void PropertyAcccesorsBody()
         {
            if (_currentToken.Type == TokenType.RwGet)
            {
               _currentToken = _lexer.GetNextToken();
               if (_currentToken.Type != TokenType.EndStatement)
                  throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
               SetAccessor();
            }else if (_currentToken.Type == TokenType.RwSet)
            {
               _currentToken = _lexer.GetNextToken();
               if (_currentToken.Type != TokenType.EndStatement)
                  throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();
               GetAccessor();
            }
         }

         private void GetAccessor()
         {
            if (_currentToken.Type == TokenType.RwProtected || _currentToken.Type == TokenType.RwPrivate ||
               _currentToken.Type == TokenType.RwPublic)
            {
                _currentToken = _lexer.GetNextToken();

            }else if(_currentToken.Type == TokenType.RwGet){
                
               _currentToken = _lexer.GetNextToken();
               if (_currentToken.Type != TokenType.EndStatement)
                  throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                 _currentToken.Column);
               _currentToken = _lexer.GetNextToken();

            }
            else
            {

            }
         }

         private void SetAccessor()
         {

            if (_currentToken.Type == TokenType.RwProtected || _currentToken.Type == TokenType.RwPrivate ||
                _currentToken.Type == TokenType.RwPublic)
            {
                _currentToken = _lexer.GetNextToken();

            }else if(_currentToken.Type == TokenType.RwSet){
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }else
            {

            }

         }

         private void PropertyAcccesorsPrivacyModifiers()
         {
            if (_currentToken.Type == TokenType.RwProtected || _currentToken.Type == TokenType.RwPrivate ||
                _currentToken.Type == TokenType.RwPublic)
               _currentToken = _lexer.GetNextToken();
            else
            {

            }
         }

         private void MethodHeader()
         {
            if (_currentToken.Type != TokenType.ParOpen)
               throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            FormalParameterList();
            if (_currentToken.Type != TokenType.ParClose)
               throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void FormalParameterList()
         {
            if (_currentToken.Type.IsType())
            {
               Parameter();
               FormalParameterListPrime();
            }
            else
            {

            }
         }

         private void FormalParameterListPrime()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               _currentToken = _lexer.GetNextToken();
               Parameter();
               FormalParameterListPrime();
            }
            else
            {

            }
         }

         private void Parameter()
         {
            TypeProduction();
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }



         private void EnumDeclaration()
         {
            if (_currentToken.Type != TokenType.RwEnum)
               throw new SintacticalException("Expected enum Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            EnumBody();
         }

         private void EnumBody()
         {
            if (_currentToken.Type != TokenType.KeyOpen)
               throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            EnumMemberDeclaration();
            if (_currentToken.Type != TokenType.KeyClose)
               throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void EnumMemberDeclaration()
         {
            if (_currentToken.Type == TokenType.Id)
            {
               EnumElement();
               EnumMemberDeclarationPrime();
            }
            else
            {
               
            }
         }

         private void EnumMemberDeclarationPrime()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               _currentToken = _lexer.GetNextToken();
               EnumElement();
               EnumMemberDeclarationPrime();
            }
            else
            {

            }
         }

         private void EnumElement()
         {
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            EnumElementBody();
         }

         private void EnumElementBody()
         {
            if (_currentToken.Type == TokenType.OpAsgn)
            {
               _currentToken = _lexer.GetNextToken();
               Expresion();
            }
            else
            {

            }
         }


         private void ClassDeclaration()
         {
            ClassModifier();
            if (_currentToken.Type != TokenType.RwClass)
               throw new SintacticalException("Expected class Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.Id)
               throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            Heredance();
            ClassBody();

         }

         private void ClassBody()
         {
            if (_currentToken.Type != TokenType.KeyOpen)
               throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            ClassMemberDeclarations();
            if (_currentToken.Type != TokenType.KeyClose)
               throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

        private void ClassMemberDeclarations()
        {


            if(_currentToken.Type.IsPrivacyModifier() || _currentToken.Type == TokenType.RwStatic || _currentToken.Type.IsType() || _currentToken.Type == TokenType.RwVoid
              ||_currentToken.Type.IsMethodModifiers() ){
                ClassMemberDeclaration();

                ClassMemberDeclarations();
            }else{
                
            }
        }

        private void ClassMemberDeclaration()
        {
            PrivacyModifier();
            FieldMethodPropertyConstructor();
        }

        private void FieldMethodPropertyConstructor()
        {
            if(_currentToken.Type== TokenType.RwStatic){
                _currentToken = _lexer.GetNextToken();
                StaticOptions();
            }
            else if(_currentToken.Type.IsType()|| _currentToken.Type==TokenType.RwVoid){
                //NonMethodModifiersMethodReturn();                
            }
            else if (_currentToken.Type.IsMethodModifiers()){
                MethodModifiers();
                //MethodReturn();
            }
            else{
                //ConstructDeclaration();
            }
        }

        private void StaticOptions()
        {
            if(_currentToken.Type==TokenType.Id){
                
                _currentToken = _lexer.GetNextToken();

                if(_currentToken.Type==TokenType.Id){
                    _currentToken = _lexer.GetNextToken();
                    FieldMethodPropertyDeclaration();
                }else if(_currentToken.Type==TokenType.ParOpen){
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type != TokenType.ParClose)
                        throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                    _currentToken = _lexer.GetNextToken();
                    Block();
                }
            }
            if(_currentToken.Type.IsType()){
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                FieldMethodPropertyDeclaration();
            }else if(_currentToken.Type==TokenType.RwVoid){
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MethodDeclaration();
            }
        }

        private void FieldMethodPropertyDeclaration()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                MethodDeclaration();
            }
            else if (_currentToken.Type == TokenType.KeyOpen)
            {
                PropertyDeclaration();
            }else{
                FieldDeclaration();
            }

        }

        private void FieldDeclaration()
        {
            FieldDeclarations();
            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
        }

        private void FieldDeclarations()
        {
            FieldAssignation();
            FieldDeclarationsPrime();
        }

        private void FieldDeclarationsPrime()
        {
            if(_currentToken.Type==TokenType.Comma){
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                FieldAssignation();
                FieldDeclarationsPrime();
            }else{
                
            }
        }

        private void FieldAssignation()
        {
            if(_currentToken.Type==TokenType.OpAsgn){
                _currentToken = _lexer.GetNextToken();
                VaraibleInitializer();
            }else{
                
            }
           
        }

        private void VaraibleInitializer()
        {
            if(_currentToken.Type==TokenType.BraOpen){
                ArrayInitalizer();
            }else{
                Expresion();
            }
        }

        private void ArrayInitalizer()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            //VaraibleInitializerListOpt();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
        }

        private void VaraibleInitializerListOpt()
        {
            throw new NotImplementedException();
        }

        private void MethodDeclaration()
        {
            MethodHeader();
            Block();
        }



        private void MethodModifiers(){
            if (_currentToken.Type.IsMethodModifiers())
                _currentToken = _lexer.GetNextToken();
        }


        private void Heredance()
         {
            if (_currentToken.Type == TokenType.Colon)
            {
               _currentToken = _lexer.GetNextToken();
               TypeName();
               Base();
            }
            else
            {

            }
         }

         private void Base()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               _currentToken = _lexer.GetNextToken();
               TypeName();
               Base();
            }
            else
            {
               
            }


         }

         private void ClassModifier()
         {
            if (_currentToken.Type.IsClassModifier())
               _currentToken = _lexer.GetNextToken();
            else
            {

            }
         }


         private void TypeProduction()
         {
            if (_currentToken.Type == TokenType.Id)
            {
                //consume()
                //if(next = id){
                //    consume();
                //}else if(next = [)
                //{
                //    consume()
                //}else if(next = ())
                //{
                //    consume()
                //}
               TypeName();
               TypeProductionPrime();
            }else if (_currentToken.Type.IsPredifinedType())
            {
               PredifinedType();
               TypeProductionPrime();

            }else if (_currentToken.Type == TokenType.RwEnum)
            {
               _currentToken = _lexer.GetNextToken();
               TypeProductionPrime();
            }
         }

         private void TypeProductionPrime()
         {
            if (_currentToken.Type == TokenType.BraOpen)
            {
               RankSpecifiers();
               TypeProductionPrime();
            }
            else
            {
               
            }
         }

         private void RankSpecifiers()
         {
           RankSpecifier();
           RankSpecifiersPrime();
         }

         private void RankSpecifiersPrime()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               _currentToken = _lexer.GetNextToken();
               RankSpecifier();
               RankSpecifiersPrime();
            }
            else
            {

            }
         }

         private void RankSpecifier()
         {
            if (_currentToken.Type != TokenType.BraOpen)
               throw new SintacticalException("Expected [ Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            DimSpearetorsOpt();
            if (_currentToken.Type != TokenType.BraClose)
               throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
         }

         private void DimSpearetorsOpt()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               DimSpearetors();
            }
            else
            {

            }
         }

         private void DimSpearetors()
         {
            if (_currentToken.Type != TokenType.Comma)
               throw new SintacticalException("Expected , Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            DimSpearetorsPrime();
         }

         private void DimSpearetorsPrime()
         {
            if (_currentToken.Type == TokenType.Comma)
            {
               _currentToken = _lexer.GetNextToken();
               DimSpearetorsPrime();
            }
            else
            {

            }
         }

         private void PredifinedType()
         {
            if (_currentToken.Type.IsPredifinedType())
               _currentToken = _lexer.GetNextToken();
         }


        private void Block()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            StatementList
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
        }




         private void Expresion()
         {
            if (_currentToken.Type == TokenType.LitNum)
               _currentToken = _lexer.GetNextToken();
         }


      }


}

