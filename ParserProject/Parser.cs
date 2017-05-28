﻿using System;
using LexerProject;
using LexerProject.Tokens;
using ParserProject.Exceptions;
using ParserProject.Extensions;
using System.Collections.Generic;
 using System.Xml.Linq;
 using ParserProject.Nodes.ExtendsNodes;
using ParserProject.Nodes.NameSpaceNodes;
using ParserProject.Nodes.StatementNodes;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ClassModifierNodes;
using ParserProject.Nodes.PrivacyModifierNodes;
using ParserProject.Nodes.NameSpaceNodes.EnumNodes;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;
using ParserProject.Nodes.ExpressionNodes.PreIdNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.LiteralNodes;
using ParserProject.Nodes.NameSpaceNodes.InterfaceNodes;
using ParserProject.BinaryOperators.ExpressionNodes.Nodes;
 using ParserProject.Nodes.ExpressionNodes.AssignationNodes;
 using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
 using ParserProject.Nodes.ExpressionNodes.CastExpresionNodes;
 using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Nodes.ExpressionNodes.NewExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
 using ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes;
 using AssignationDivStatementNode = ParserProject.Nodes.StatementNodes.AssignationDivStatementNode;
 using AssignationEqualStatementNode = ParserProject.Nodes.StatementNodes.AssignationEqualStatementNode;
 using AssignationLftShftStatementNode = ParserProject.Nodes.StatementNodes.AssignationLftShftStatementNode;
 using AssignationModStatementNode = ParserProject.Nodes.StatementNodes.AssignationModStatementNode;
 using AssignationMultStatemntNode = ParserProject.Nodes.StatementNodes.AssignationMultStatemntNode;
 using AssignationOrStatementNode = ParserProject.Nodes.StatementNodes.AssignationOrStatementNode;
 using AssignationRghtShftStatementNode = ParserProject.Nodes.StatementNodes.AssignationRghtShftStatementNode;
 using AssignationSumStatementNode = ParserProject.Nodes.StatementNodes.AssignationSumStatementNode;

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

        public Parser(){
            
        }

        public List<CodeNode> Parse()
        {
             var codeList=Code();

            if (_currentToken.Type != TokenType.Eof)
                throw new SintacticalException("Expected Eof");
            return codeList;
        }

        private List<CodeNode> Code()
        {
            return NameSpaceList();
        }

        private List<CodeNode> NameSpaceList()
        {
            if (_currentToken.Type.IsNameSpace())
            {
                var namespaceNode=NameSpace();
                var list=NameSpaceList();
                list.Insert(0,namespaceNode);
                return list;
            }
            else
            {
                return new List<CodeNode>();
            }

        }

        private CodeNode NameSpace()
        {
            var usingDirectiveList=UsingDirectives();
            var namespaceDeclarationList=NameSpaceDeclarations();
            return new CodeNode{UsingDirectiveList=usingDirectiveList,NameSpaceDeclarationList=namespaceDeclarationList};
        }

        private List<UsingDirectiveNode> UsingDirectives()
        {
            if (_currentToken.Type == TokenType.RwUsing)
            {
                var usingdirective=UsingDirective();
                var list=UsingDirectives();
                list.Insert(0,usingdirective);
                return list;
            }
            else
            {
                return new List<UsingDirectiveNode>();
            }
        }

        private UsingDirectiveNode UsingDirective()
        {
            if (_currentToken.Type != TokenType.RwUsing)
                throw new SintacticalException("Expected using Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var idtype=TypeName();
            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " + _currentToken.Column);
            _currentToken = _lexer.GetNextToken();

            return new UsingDirectiveNode(idtype);
        }

        private IdTypeNode TypeName()
        {
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var idnode=TypeNamePrime();
            return new IdTypeNode(idlexeme, idnode);
        }

        private IdTypeNode TypeNamePrime()
        {
            if (_currentToken.Type == TokenType.Period)
            {
                var idlexeme = _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var idnode = TypeNamePrime();
                return new IdTypeNode(idlexeme.Lexeme, idnode);
            }
            else
            {
                return null;
            }
        }

        private List<NameSpaceDeclarationNode> NameSpaceDeclarations()
        {
            if (_currentToken.Type.IsPrivacyModifier() || _currentToken.Type == TokenType.RwNamespace || _currentToken.Type.IsClassModifier() || _currentToken.Type == TokenType.RwClass
                || _currentToken.Type == TokenType.RwInterface || _currentToken.Type == TokenType.RwEnum)
            {
                var nameSpaceNode=NameSpaceDeclaration();
                var list=NameSpaceDeclarations();
                list.Insert(0,nameSpaceNode);
                return list;
            }
            else
            {
                return new List<NameSpaceDeclarationNode>();
            }
        }

        private NameSpaceDeclarationNode NameSpaceDeclaration()
        {
            if (_currentToken.Type == TokenType.RwNamespace)
            {
                return NameSpaceStatement();
            }
            else
            {
                var privacyNode=PrivacyModifier();
                return ClassInterfaceEnum(privacyNode);
            }

        }

        private NameSpaceNode NameSpaceStatement()
		{
			if (_currentToken.Type != TokenType.RwNamespace)
				throw new SintacticalException("Expected Namespace Line " + _currentToken.Line + " Col " +
											   _currentToken.Column);
			_currentToken = _lexer.GetNextToken();
			var id = TypeName();
			var code = NameSpaceBody();
            return new NameSpaceNode { IdNode = id ,Code=code };

		}

        private CodeNode NameSpaceBody()
		{
			if (_currentToken.Type != TokenType.KeyOpen)
				throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
											   _currentToken.Column);
			_currentToken = _lexer.GetNextToken();
			var codeNode=NameSpace();
			if (_currentToken.Type != TokenType.KeyClose)
				throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
											   _currentToken.Column);
			_currentToken = _lexer.GetNextToken();
            return codeNode;
		}

        private PrivacyModifierNode PrivacyModifier()
        {
            if (_currentToken.Type == TokenType.RwPublic)
            {
                _currentToken = _lexer.GetNextToken();
                return new PublicNode();
            }
            else if (_currentToken.Type == TokenType.RwPrivate)
            {
                _currentToken = _lexer.GetNextToken();
                return new PrivateNode();
            }
            else if (_currentToken.Type == TokenType.RwProtected)
            {
                _currentToken = _lexer.GetNextToken();
                return new ProtectedNode();
            }
            else
            {
                return null;
            }
        }

        private NameSpaceDeclarationNode ClassInterfaceEnum(PrivacyModifierNode privacyNode)
        {
            if (_currentToken.Type == TokenType.RwInterface)
            {
                var interfaceStructure = InterfaceDeclaration();
                return new InterfaceDeclarationNode { PrivacyModifierNode = privacyNode, InterfaceStructure = interfaceStructure };

            }
            else if (_currentToken.Type == TokenType.RwEnum)
            {
                var enumstructure=EnumDeclaration();
                return new EnumDeclarationNode { PrivacyModifierNode = privacyNode, EnumStructure = enumstructure };
            }
            else if (_currentToken.Type == TokenType.RwClass || _currentToken.Type.IsClassModifier())
            {
                var classStructure = ClassDeclaration();
                return new ClassDeclarationNode { PrivacyModifierNode = privacyNode, ClassStructure = classStructure  };
            }
            else
                throw new SintacticalException("Expected inteface,enum,class or class modifiers Line " +
                                               _currentToken.Line + " Col " +
                                               _currentToken.Column);
        }

        private InterfaceStructureNode InterfaceDeclaration()
        {
            if (_currentToken.Type != TokenType.RwInterface)
                throw new SintacticalException("Expected interface Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            var idlexeme=_currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var extendsNode=Heredance();
            var body=InterfaceBody();
            return new InterfaceStructureNode(idlexeme.Lexeme, extendsNode,body);
        }

        private InterfaceBodyNode InterfaceBody()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list=InterfaceMemberDeclarations();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new InterfaceBodyNode{ InterfaceMethodList = list};
        }

        private List<InterfaceMethodNode> InterfaceMemberDeclarations()
        {
            if (_currentToken.Type.IsType() || _currentToken.Type == TokenType.RwVoid)
            {
                var interfaceMethod = InterfaceElement();
                var list=InterfaceMemberDeclarations();
                list.Insert(0,interfaceMethod);
                return list;
            }
            else
            {
                return new List<InterfaceMethodNode>();
            }
        }

        private InterfaceMethodNode InterfaceElement()
        {
            if (_currentToken.Type.IsType())
            {
                var typeNode=TypeProduction();

                var idLexeme = _currentToken.Lexeme;
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var parameterLst=MethodProperty();

                return new InterfaceMethodNode { TypeNode = typeNode, Name = idLexeme ,  ParameterList=parameterLst };
            }
            else if (_currentToken.Type == TokenType.RwVoid)
            {
                var voidNode = new VoidTypeNode();
                var idLexeme=_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var list=MethodProperty();

                return new InterfaceMethodNode { TypeNode = voidNode, Name = idLexeme.Lexeme, ParameterList = list };
            }
            else
            {
                throw new SintacticalException("Expected type or void Line " + _currentToken.Line + " Col " +
                                                _currentToken.Column);
            }
        }

        private List<ParameterNode> MethodProperty()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                var list=MethodHeader();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return list;
            }
            else
            {
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                                _currentToken.Column);
            }
        }

        private List<ParameterNode> MethodHeader()
        {
            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var parameterlist=FormalParameterList();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return parameterlist;
        }

        private List<ParameterNode> FormalParameterList()
        {
            if (_currentToken.Type.IsType())
            {
                var p=Parameter();
                var list=FormalParameterListPrime();
                list.Insert(0,p);
                return list;
            }
            else
            {
                return new List<ParameterNode>();
            }
        }

        private List<ParameterNode> FormalParameterListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var parameter=Parameter();
                var list=FormalParameterListPrime();
                list.Insert(0,parameter);
                return list;
            }
            else
            {
                return new List<ParameterNode>();
            }
        }

        private ParameterNode Parameter()
        {
            var type=TypeProduction();
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new ParameterNode { typeNode = type, Name = idlexeme };
        }

        private EnumStructureNode EnumDeclaration()
        {
            if (_currentToken.Type != TokenType.RwEnum)
                throw new SintacticalException("Expected enum Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            
            _currentToken = _lexer.GetNextToken();
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var enumbody=EnumBody();
            return new EnumStructureNode { Name=idlexeme , Body=enumbody };
        }

        private EnumBodyNode EnumBody()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list=EnumMemberDeclaration();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new EnumBodyNode {  EnumElementList = list };
        }

        private List<EnumElementNode> EnumMemberDeclaration()
        {
            if (_currentToken.Type == TokenType.Id)
            {
				var element = EnumElement();
				var list = EnumMemberDeclarationPrime();
				list.Insert(0, element);
				return list;
            }
            else
            {
                return new List<EnumElementNode>();
            }
        }

        private List<EnumElementNode> EnumMemberDeclarationPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var element=EnumElement();
                var list=EnumMemberDeclarationPrime();
                list.Insert(0,element);
                return list;
            }
            else
            {
                return new List<EnumElementNode>();
            }
        }

        private EnumElementNode EnumElement()
        {
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var expressionNode=EnumElementBody();
            return new EnumElementNode { Name = idlexeme, Expression = expressionNode };
        }

        private ExpressionNode EnumElementBody()
        {
            if (_currentToken.Type == TokenType.OpAsgn)
            {
                _currentToken = _lexer.GetNextToken();
                return Expresion();
            }
            else
            {
                return null;
            }
        }

        private ClassStructureNode ClassDeclaration()
        {
            var classModifier=ClassModifier();
            if (_currentToken.Type != TokenType.RwClass)
                throw new SintacticalException("Expected class Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            var idlexeme=_currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var extendsNode=Heredance();
            var body= ClassBody();
            return  new ClassStructureNode{ModifierNode = classModifier,Name = idlexeme.Lexeme,ExtendsNode = extendsNode,Body = body};
        }

        private ClassBodyNode ClassBody()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list=ClassMemberDeclarations();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new ClassBodyNode{ClassMemberDeclarationList = list };
        }

        private List<ClassMemberDeclaration> ClassMemberDeclarations()
        {

            if (_currentToken.Type.IsPrivacyModifier() || _currentToken.Type == TokenType.RwStatic || _currentToken.Type.IsType() || _currentToken.Type == TokenType.RwVoid
              || _currentToken.Type.IsMethodModifiers())
            {

                var x=ClassMemberDeclaration();
                var list=ClassMemberDeclarations();
                list.Insert(0,x);
                return list;
            }
            else
            {
                return new List<ClassMemberDeclaration>();
            }
        }

        private ClassMemberDeclaration ClassMemberDeclaration()
        {
            var privacyNode=PrivacyModifier();
            if (_currentToken.Type == TokenType.RwAbstract)
            {
                _currentToken = _lexer.GetNextToken();
                var x=InterfaceElement();
                
                return new ClassAbstractMemberDeclaration { PrivacyNode = privacyNode, Name = x.Name,ParameterList = x.ParameterList,TypeNode = x.TypeNode};
            }
            else
            {
                FieldMethodPropertyConstructor();
            }
        }

        private void FieldMethodPropertyConstructor()
        {
            if (_currentToken.Type == TokenType.RwStatic)
            {
                _currentToken = _lexer.GetNextToken();
                StaticOptions();
            }
            else if (_currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum)
            {
                CustomTypeProduction();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                FieldMethodPropertyDeclaration();
            }
            else if (_currentToken.Type == TokenType.RwVoid)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MethodDeclaration();
            }
            else if (_currentToken.Type.IsMethodModifiers())
            {
                MethodModifiers();
                MethodReturn();
            }
            else if (_currentToken.Type == TokenType.Id)
            {
                TypeName();
                TypeProductionPrime();
                Mierda3();
            }
            else
            {
                throw new SintacticalException("Expected Primitive type, enum , void, static , Id or method modifiers Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
            }
        }

        private void Mierda3()
        {
            if (_currentToken.Type == TokenType.Id)
            {
                _currentToken = _lexer.GetNextToken();
                FieldMethodPropertyDeclaration();
            }
            else if (_currentToken.Type == TokenType.ParOpen)
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
                ConstructorInitializer();
                Block();
            }
            else
            {
                throw new SintacticalException("Expected Id or ( Line " + _currentToken.Line + " Col " +
                                                     _currentToken.Column);
            }

        }

        private void ConstructorInitializer()
        {
            if (_currentToken.Type == TokenType.Colon)
            {
                _currentToken = _lexer.GetNextToken();
                ConstructorInitializerPrime();
            }
            else
            {

            }
        }

        private void ConstructorInitializerPrime()
        {
            if (_currentToken.Type == TokenType.RwBase || _currentToken.Type == TokenType.RwThis)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.ParOpen)
                    throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                ArgumentList();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }
        }

        private List<ExpressionNode> ArgumentList()
        {
            if (_currentToken.Type.IsExpression())
            {
                var exp=Expresion();
                var list=ArgumentListPrime();
                list.Insert(0,exp);
                return list;
            }
            else
            {
				return new List<ExpressionNode>();
            }
        }

        private List<ExpressionNode> ArgumentListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var exp=Expresion();
                var list=ArgumentListPrime();
                list.Insert(0,exp);
                return list;
            }
            else
            {
                return new List<ExpressionNode>();
            }
        }

        private void MethodReturn()
        {
            if (_currentToken.Type == TokenType.RwVoid)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MethodDeclaration();
            }
            else if (_currentToken.Type.IsType())
            {
                TypeProduction();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MethodPropertyDeclaration();
            }
            else
            {
                throw new SintacticalException("Expected void or type Line " + _currentToken.Line + " Col " +
                                                  _currentToken.Column);
            }
        }

        private void MethodPropertyDeclaration()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                MethodDeclaration();
            }
            else
            {
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                                  _currentToken.Column);
            }
        }

        private void StaticOptions()
        {
            if (_currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum)
            {
                CustomTypeProduction();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                FieldMethodPropertyDeclaration();
            }
            else if (_currentToken.Type == TokenType.RwVoid)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MethodDeclaration();
            }
            else if (_currentToken.Type == TokenType.Id)
            {
                TypeName();
                TypeProductionPrime();
                Mierda2();
            }
            else
            {
                throw new SintacticalException("Expected Primitive type ,enum,void or id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
            }
        }

        private void Mierda2()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                Block();
            }
            else if (_currentToken.Type == TokenType.Id)
            {
                _currentToken = _lexer.GetNextToken();
                FieldMethodPropertyDeclaration();
            }
            else
            {
                throw new SintacticalException("Expected ( or Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
            }

        }

        private void FieldMethodPropertyDeclaration()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                MethodDeclaration();
            }
            else
            {
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
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                FieldAssignation();
                FieldDeclarationsPrime();
            }
            else
            {

            }
        }

        private void FieldAssignation()
        {
            if (_currentToken.Type == TokenType.OpAsgn)
            {
                _currentToken = _lexer.GetNextToken();
                VaraibleInitializer();
            }
            else
            {

            }

        }

        private ExpressionNode VaraibleInitializer()
        {
            if (_currentToken.Type == TokenType.KeyOpen)
            {
                return ArrayInitalizer();
            }
            else if (_currentToken.Type.IsExpression())
            {
                return Expresion();
            }
            else
            {
                throw new SintacticalException("Expected valid variable initalizer Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private ArrayInitalizerNode ArrayInitalizer()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list=VaraibleInitializerListOpt();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new ArrayInitalizerNode { ExpressionList = list};
        }

        private void MethodDeclaration()
        {
            MethodHeader();
            Block();
        }

        private void MethodModifiers()
        {
            if (_currentToken.Type.IsMethodModifiers())
                _currentToken = _lexer.GetNextToken();
        }

        private ExtendsNode Heredance()
        {
            if (_currentToken.Type == TokenType.Colon)
            {
                _currentToken = _lexer.GetNextToken();
                var idnode=TypeName();
                var list=Base();
                list.Insert(0,idnode);
                return new ExtendsNode(list);
            }
            else
            {
                return null;
            }
        }

        private List<IdTypeNode> Base()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var idNode = TypeName();
                var list=Base();
                list.Insert(0,idNode);
                return list;
            }
            else
            {
                return new List<IdTypeNode>();
            }
        }

        private ClassModifierNode ClassModifier()
        {
            if (_currentToken.Type == TokenType.RwStatic)
            {
                _currentToken = _lexer.GetNextToken();
                return new StaticNode();
            }else if (_currentToken.Type==TokenType.RwAbstract)
            {
                _currentToken = _lexer.GetNextToken();
                return new AbstractNode();
            }
            else
            {
                return null;
            }
        }

        private TypeProductionNode TypeProduction()
        {
            if (_currentToken.Type == TokenType.Id)
            {
                var idNode=TypeName();
                var rankspecfiers=TypeProductionPrime();
                return new IdTypeProductionNode { IdType  = idNode,rankSpecifiers = rankspecfiers };
            }
            else if (_currentToken.Type.IsPredifinedType())
            {
                var primitivetypeNode=PredifinedType();
                var rankspecifiers=TypeProductionPrime();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode , rankSpecifiers=rankspecifiers };

            }
            else if (_currentToken.Type == TokenType.RwEnum)
            {
                var primitivetypeNode = new PrimitiveEnumNode();
                _currentToken = _lexer.GetNextToken();
               var rankspecifiers= TypeProductionPrime();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode, rankSpecifiers = rankspecifiers };
            }
            else
            {
                throw new SintacticalException("Expected valid type Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            }
        }

        private TypeProductionNode CustomTypeProduction()
        {
            if (_currentToken.Type.IsPredifinedType())
            {
                var primitivetypeNode = PredifinedType();
                var rankspecifiers = TypeProductionPrime();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode, rankSpecifiers = rankspecifiers };
            }
            else if (_currentToken.Type == TokenType.RwEnum)
            {
                var primitivetypeNode = new PrimitiveEnumNode();
                _currentToken = _lexer.GetNextToken();
                var rankspecifiers = TypeProductionPrime();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode, rankSpecifiers = rankspecifiers };
            }
            else
            {
                throw new SintacticalException("Expected Primitve type or Enum Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }

        }

        private TypeProductionNode TypeProductionForArrayOrObject()
        {
            if (_currentToken.Type == TokenType.Id)
            {
                var idNode=TypeName();
                return new IdTypeProductionNode { IdType = idNode };
            }
            else if (_currentToken.Type.IsPredifinedType())
            {
                var primitivetypeNode = PredifinedType();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode};

            }
            else if (_currentToken.Type == TokenType.RwEnum)
            {
                var primitivetypeNode = new PrimitiveEnumNode();
                _currentToken = _lexer.GetNextToken();
                return new PrimitiveTypeProductionNode { primitiveType = primitivetypeNode};
            }
            else
            {
                throw new SintacticalException("Expected valid type Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private List<RankSpeciferNode> TypeProductionPrime()
        {
            if (_currentToken.Type == TokenType.BraOpen)
            {
                return RankSpecifiers();
                //TypeProductionPrime();
            }
            else
            {
                return null;
            }
        }

        private List<RankSpeciferNode> RankSpecifiers()
        {
            var r=RankSpecifier();
            var list=RankSpecifiersPrime();
            list.Insert(0,r);
            return list;
        }

        private List<RankSpeciferNode> RankSpecifiersPrime()
        {
            if (_currentToken.Type == TokenType.BraOpen)
            {
                var r=RankSpecifier();
                var list=RankSpecifiersPrime();
                list.Insert(0,r);
                return list;
            }
            else
            {
                return new List<RankSpeciferNode>();
            }
        }

        private RankSpeciferNode  RankSpecifier()
        {
            if (_currentToken.Type != TokenType.BraOpen)
                throw new SintacticalException("Expected [ Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list= DimSpearetorsOpt();
            if (_currentToken.Type != TokenType.BraClose)
                throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new RankSpeciferNode { DimSeparatorList = list };

        }

        private List<DimSeparatorNode> DimSpearetorsOpt()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                return DimSpearetors();
            }
            else
            {
                return null;
            }
        }

        private List<DimSeparatorNode> DimSpearetors()
        {
            if (_currentToken.Type != TokenType.Comma)
                throw new SintacticalException("Expected , Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var dim = new DimSeparatorNode();
            var list=DimSpearetorsPrime();
            list.Insert(0,dim);
            return list;
        }

        private List<DimSeparatorNode> DimSpearetorsPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                var dim = new DimSeparatorNode();
                _currentToken = _lexer.GetNextToken();
                var list=DimSpearetorsPrime();
                list.Insert(0,dim);
                return list;

            }
            else
            {
                return new List<DimSeparatorNode>();
            }
        }

        private PrimitiveTypeNode PredifinedType()
        {
				if (_currentToken.Type == TokenType.RwBool)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveBoolNode();
				}
				if (_currentToken.Type == TokenType.RwChar)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveCharNode();
				}
				if (_currentToken.Type == TokenType.RwInt)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveIntNode();
				}
				if (_currentToken.Type == TokenType.RwFloat)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveFloatNode();
				}
				if (_currentToken.Type == TokenType.RwString)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveStringNode();
				}
				if (_currentToken.Type == TokenType.RwEnum)
				{
                    _currentToken = _lexer.GetNextToken();
					return new PrimitiveEnumNode();
				}
            else{
				throw new SintacticalException("Expected primitive type Line " + _currentToken.Line + " Col " +
											   _currentToken.Column);
            }
                 
        }

        private List<StatementNode> Block()
        {
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list = StatementList();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return list;
        }

        private List<ExpressionNode> VaraibleInitializerListOpt()
        {
            if (_currentToken.Type == TokenType.KeyOpen || _currentToken.Type.IsExpression())
            {
                return VaraibleInitializerList();
            }
            else
            {
                return null;
            }
        }

        private List<ExpressionNode> VaraibleInitializerList()
        {
            var expression=VaraibleInitializer();
            var list=VaraibleInitializerListPrime();
            list.Insert(0,expression);
            return list;
        }

        private List<ExpressionNode> VaraibleInitializerListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var exp=VaraibleInitializer();
                var list=VaraibleInitializerListPrime();
                list.Insert(0,exp);
                return list;
            }
            else
            {
                return new List<ExpressionNode>();
            }
        }

        private List<StatementNode> StatementList()
        {
            if (_currentToken.Type.IsStatements())
            {
                var statement = Statement();
                var list = StatementList();
                list.Insert(0, statement);
                return list;
            }
            else
            {
                return new List<StatementNode>();
            }
        }

        private StatementNode Statement()
        {
            if (_currentToken.Type == TokenType.RwIf)
            {
                return IfStatement();
            }
            else if (_currentToken.Type == TokenType.RwWhile)
            {
                return WhileStatement();
            }
            else if (_currentToken.Type == TokenType.RwDo)
            {
                return DoStatement();
            }
            else if (_currentToken.Type == TokenType.RwSwitch)
            {
                return SwitchStatement();
            }
            else if (_currentToken.Type == TokenType.RwReturn)
            {
                return ReturnStatement();
            }
            else if (_currentToken.Type == TokenType.RwBreak)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new BreakNodeStatement();
            }
            else if (_currentToken.Type == TokenType.RwContinue)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new ContinueNodeStatement();
            }
            else if (_currentToken.Type == TokenType.EndStatement)
            {
                _currentToken = _lexer.GetNextToken();
                return new EndNodeStatement();
            }
            else if (_currentToken.Type == TokenType.RwForeach)
            {
                return ForEachStatement();
            }
            else if (_currentToken.Type == TokenType.RwFor)
            {
                return ForStatement();
            }
            else if (_currentToken.Type == TokenType.OpDec)
            {
                _currentToken = _lexer.GetNextToken();
                var primary=PrimaryExpression();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new DecrementStatement { ExpressionNode = primary };
            }
            else if (_currentToken.Type == TokenType.OpInc)
            {
                _currentToken = _lexer.GetNextToken();
                var primary = PrimaryExpression();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new IncrementStatement { ExpressionNode = primary };
            }
            else if (_currentToken.Type == TokenType.RwVar || _currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum
                || _currentToken.Type == TokenType.RwBase || _currentToken.Type == TokenType.RwThis || _currentToken.Type == TokenType.Id)
            {
                var x=DeclarationAsignationStatement();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return x;
            }
            else if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var castExp=CastStatement();
                if (_currentToken.Type != TokenType.Period)
                    throw new SintacticalException("Expected . Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
     
                var idLexeme = _currentToken = _lexer.GetNextToken();
               

                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var x = new PeriodAccessor { ParentId = idLexeme.Lexeme, Accessor = null };
                var y= new  ParentesisExpresionNode{ExpresioNode = castExp,AccesorExpression = x};
                var accessor=IdExpression();

                var z =  new ParentesisExpresionNode{ExpresioNode = y,AccesorExpression = accessor};
                if (_currentToken.Type == TokenType.OpAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationEqualStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpAddAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationSumStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpSubAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationSubStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpMulAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationMultStatemntNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpDivAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationDivStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpModAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationModStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpAndAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationAndStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpOrAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationOrStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpXorAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationXorStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpLftShftAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationLftShftStatementNode(z, right);
                }
                if (_currentToken.Type == TokenType.OpRghtShftAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationRghtShftStatementNode(z, right);
                }
                return new AssignationNodeStatement { LeftValue = z };
            }
            else if (_currentToken.Type == TokenType.KeyOpen)
            {
                var list = Block();
                return new BlockNodeStatement(list);
            }
            else
            {
                throw new SintacticalException("Expected Statement Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
            }
        }

        private CastExpressionNode CastStatement()
        {

            if (_currentToken.Type.IsType())
            {
                var type=TypeProduction();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var p=PrimaryExpression();
                return new CastExpressionNode {Left = type, Right = p};
            }
            else if (_currentToken.Type == TokenType.ParOpen)
            {
                return CastStatementPrime();
            }
            else
            {
                throw new SintacticalException("Expected type or ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private CastExpressionNode CastStatementPrime()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var exp=CastStatement();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return exp;
            }
            else
            {
                return null;
            }
        }
        private StatementNode DeclarationAsignationStatement()
        {
            if (_currentToken.Type == TokenType.RwVar)
            {
                var type= new VarTypeNode();
                _currentToken = _lexer.GetNextToken();
                var declarationList=DeclaratorsList();
                return new DeclarationNodeStatement{Type = type , DeclarationList = declarationList};

            }
            else if (_currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum)
            {
                var primitive = PredifinedType();
                return DeclaratorsListOrPrimitiveAccessor(primitive);
            }
            else if (_currentToken.Type == TokenType.RwBase || _currentToken.Type == TokenType.RwThis)
            {
                PreIdExpressionNode preId=null;
                if(_currentToken.Type == TokenType.RwBase)
                    preId= new BaseExpressionNode();
                else
                    preId = new BaseExpressionNode();

               _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Period)
                    throw new SintacticalException("Expected . Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                var idlexeme=_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessorNode=IdExpression();
                var left = new IdLeftExpressionNode();
                left.Accessor = accessorNode;
                left.PreId = preId;
                left.Name = new IdTypeNode(idlexeme.Lexeme, null);
                if (_currentToken.Type == TokenType.OpAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationEqualStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpAddAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationSumStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpSubAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationSubStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpMulAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationMultStatemntNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpDivAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationDivStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpModAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationModStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpAndAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationAndStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpOrAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationOrStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpXorAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationXorStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpLftShftAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationLftShftStatementNode(left, right);
                }
                if (_currentToken.Type == TokenType.OpRghtShftAsgn)
                {
                    var right = Expresion();
                    _currentToken = _lexer.GetNextToken();
                    return new AssignationRghtShftStatementNode(left, right);
                }
                return new AssignationNodeStatement {LeftValue = left};
            }
            else if (_currentToken.Type == TokenType.Id)
            {

                var idlexeme=_currentToken = _lexer.GetNextToken();
                return WWWWW(idlexeme.Lexeme);
            }
            else
            {
                throw new SintacticalException("Expected declaration asignation Statement Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private StatementNode DeclaratorsListOrPrimitiveAccessor(PrimitiveTypeNode primitive)
        {
            if (_currentToken.Type == TokenType.Period)
            {
                var idlexeme=_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor=IdExpression();
                return new PrimitiveTypeAccessorStatement{Type = primitive,Name = idlexeme.Lexeme,Accesor = accessor};
            }
            else
            {
                var rank=TypeProductionPrime();
                var typeProduction = new PrimitiveTypeProductionNode {primitiveType = primitive ,rankSpecifiers = rank};
                var list=DeclaratorsList();
                return new DeclarationNodeStatement {Type = typeProduction, DeclarationList = list};
            }
        }

        private StatementNode WWWWW(string idName)
        {
            var x=TypeNamePrime();
            return YYYYY(idName,x);
        }

        private StatementNode YYYYY(string idName,IdTypeNode idNode)
        {
            if (_currentToken.Type == TokenType.BraOpen)
            {
                _currentToken = _lexer.GetNextToken();
                IdTypeNode idTypeNode = new IdTypeNode(idName, idNode);
                return YYYYYPrime(idTypeNode);
            }
            else if (_currentToken.Type == TokenType.Id)
            {
                var listDeclarations = DeclaratorsList();
                IdTypeNode type = new IdTypeNode(idName,idNode);
               return new DeclarationNodeStatement { Type = type, DeclarationList = listDeclarations };
            }
            else
            {
                var accesorNode=IdExpressionWithoutOpenBra();
                var idleft = new IdLeftExpressionNode();
                idleft.Accessor = accesorNode;
                idleft.PreId = null;
                IdTypeNode type = new IdTypeNode(idName, idNode);
                idleft.Name = type;
                return XXXX(idleft);
            }
        }

        private StatementNode XXXX(ExpressionNode idleft)
        {
            if (_currentToken.Type == TokenType.OpDec)
            {
                _currentToken = _lexer.GetNextToken();
                return new AssignationNodeStatement {LeftValue = idleft, RightValue = new DecNode()};
            }
            else if (_currentToken.Type == TokenType.OpInc)
            {
                _currentToken = _lexer.GetNextToken();
                return new AssignationNodeStatement { LeftValue = idleft, RightValue = new IncNode() };
            }
            else if (_currentToken.Type.IsAssignationOperator())
            {
                _currentToken = _lexer.GetNextToken();
                var exp = Expresion();
                return new AssignationNodeStatement { LeftValue = idleft, RightValue = exp };
                //AssignmentStatementList();
            }
            else
            {
                throw new SintacticalException("Expected ++ , -- or assign operator Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private AccesorExpressionNode IdExpressionWithoutOpenBra()
        {
            if (_currentToken.Type == TokenType.Period)
            {
                var idlexeme = _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor = IdExpression();
                if (accessor != null)
                    accessor.ParentId = idlexeme.Lexeme;
                return new PeriodAccessor { ParentId = idlexeme.Lexeme, Accessor = accessor };
            }
            else if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var expresionl = ArgumentList();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor = ParentesisExpression();
                return new ParentesisAccessor { Accessor = accessor, expresionList = expresionl };

            }
            else
            {
                return null;
            }
        }

        private StatementNode YYYYYPrime(IdTypeNode idTypeNode)
        {
            if (_currentToken.Type.IsExpression())
            {
                var accessor = Mierda4();
                var idleft = new IdLeftExpressionNode();
                idleft.Name = idTypeNode;
                idleft.PreId = null;
                idleft.Accessor = accessor;      
                return XXXX(idleft);
            }
            else
            {
                var rankspecifier=RankSpecifierDec();
                var listRankSpecifiers=TypeProductionPrime();
                listRankSpecifiers.Insert(0,rankspecifier);
                var listdeclartion=DeclaratorsList();

                var id = new IdTypeProductionNode();
                id.rankSpecifiers = listRankSpecifiers;
                id.IdType = idTypeNode;

                return new DeclarationNodeStatement {DeclarationList = listdeclartion, Type = id};
            }
        }

        private AccesorExpressionNode Mierda4()
        {
           var expresionList= ExpresionList();
            if (_currentToken.Type != TokenType.BraClose)
                throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var accessor=IdExpression();
            return new BracketAccessor { expresionList = expresionList, Accessor = accessor };
        }

        private RankSpeciferNode RankSpecifierDec()
        {
            var list=DimSpearetorsOpt();
            if (_currentToken.Type != TokenType.BraClose)
                throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new RankSpeciferNode { DimSeparatorList = list };

        }

        private List<DeclaratorNode> DeclaratorsList()
        {
            var declarator=Declarator();
            var list=DeclaratorsListPrime();
            list.Insert(0,declarator);
            return list;
        }

        private List<DeclaratorNode> DeclaratorsListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var declarator=Declarator();
                var list=DeclaratorsListPrime();
                list.Insert(0,declarator);
                return list;
            }
            else if (_currentToken.Type == TokenType.OpAsgn)
            {
                _currentToken = _lexer.GetNextToken();
                var expression=VaraibleInitializer();
                var d= new DeclaratorNode{Expression = expression};
                var list=DeclaratorsListPrime();
                list.Insert(0,d);
                return list;
            }
            else
            {
                return new List<DeclaratorNode>();
            }
        }

        private DeclaratorNode Declarator()
        {
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)

                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var expression =DeclaratorPrime();
            return new DeclaratorNode{Name = idlexeme,Expression =expression };
        }

        private ExpressionNode DeclaratorPrime()
        {
            if (_currentToken.Type == TokenType.OpAsgn)
            {
                _currentToken = _lexer.GetNextToken();
                return VaraibleInitializer();
            }
            else
            {
                return null;
            }
        }

        private ForNodeStatement ForStatement()
        {  
            if (_currentToken.Type != TokenType.RwFor)
                throw new SintacticalException("Expected for Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var declarationAsignation=ForInitalizer();
            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var exp=ExpresionOpt();
            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var  explist = ExpresionListOpt();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var statementlist=EmbededStatement();

            return new ForNodeStatement(declarationAsignation,exp,explist,statementlist);
        }

        private List<ExpressionNode> ExpresionListOpt()
        {
            if(_currentToken.Type.IsExpression()){
                return ExpresionList();
            }else{
                return null;
            }
        }

        private ExpressionNode ExpresionOpt()
        {
            if (_currentToken.Type.IsExpression())
            {
                return Expresion();
            }
            else{
                return null;
            }
        }

        private StatementNode ForInitalizer()
        {
            if (_currentToken.Type == TokenType.RwVar || _currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum
                || _currentToken.Type == TokenType.RwBase || _currentToken.Type == TokenType.RwThis || _currentToken.Type == TokenType.Id)
                return DeclarationAsignationStatement();
            else
            {
                return null;
            }
        }

        private List<ExpressionNode> ExpresionList()
        {
            if (_currentToken.Type.IsExpression())
            {
                var exp=Expresion();
                var list=ExpresionListPrime();
                list.Insert(0, exp);
                return list;

            }
            else
            {
                throw new SintacticalException("Expected expression Line " + _currentToken.Line + " Col " +
                                              _currentToken.Column);
            }
        }

        private List<ExpressionNode> ExpresionListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                var exp=Expresion();
                var list=ExpresionListPrime();
                list.Insert(0,exp);
                return list;
            }
            else
            {
                return new List<ExpressionNode>();
            }
        }

        private ForEachNodeStatement ForEachStatement()
        {
            if (_currentToken.Type != TokenType.RwForeach)

                throw new SintacticalException("Expected foreach Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var typenode = LocalVariableType();
            var idlexeme = _currentToken.Lexeme;
            if (_currentToken.Type != TokenType.Id)
                throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.RwIn)
                throw new SintacticalException("Expected in Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var exp = Expresion();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list=EmbededStatement();

            return new ForEachNodeStatement(typenode, idlexeme, exp, list);
        }

        private TypeExpressionNode LocalVariableType()
        {
            if (_currentToken.Type == TokenType.RwVar)
            {
                _currentToken = _lexer.GetNextToken();
                return new VarTypeNode();
            }
            else if (_currentToken.Type.IsType())
            {
                return TypeProduction();
            }
            else
            {
                throw new SintacticalException("Expected var or type Line " + _currentToken.Line + " Col " +
                                                _currentToken.Column);
            }
        }

        private ReturnNodeStatement ReturnStatement()
        {
            if (_currentToken.Type != TokenType.RwReturn)
                throw new SintacticalException("Expected return Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var exp = ReturnBody();
            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new ReturnNodeStatement(exp);
        }

        private ExpressionNode ReturnBody()
        {
            if (_currentToken.Type.IsExpression())
                return Expresion();
            else
            {
                return null;
            }
        }

        private StatementNode SwitchStatement()
        {
            if (_currentToken.Type != TokenType.RwSwitch)
                throw new SintacticalException("Expected switch Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var expToEvaluate = Expresion();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.KeyOpen)
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var cases = SwitchSections();
            var @default = DefaultStatement();
            if (_currentToken.Type != TokenType.KeyClose)
                throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new SwitchStatementNode(expToEvaluate, cases, @default);
        }

        private DefaultCaseNodeStatement DefaultStatement()
        {
            if (_currentToken.Type == TokenType.RwDefault)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Colon)
                    throw new SintacticalException("Expected : Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var list = StatementList();
                var @break = BreakStatement();
                return new DefaultCaseNodeStatement(list, @break);
            }
            else
            {
                return null;
            }
        }

        private List<CaseNodeStatement> SwitchSections()
        {
            if (_currentToken.Type == TokenType.RwCase)
            {
                var @case = SwitchSection();
                var caseList = SwitchSections();
                caseList.Insert(0, @case);
                return caseList;
            }
            else
            {
                return new List<CaseNodeStatement>();
            }
        }

        private CaseNodeStatement SwitchSection()
        {
            var exp = SwitchLables();
            var body = StatementList();
            var @break = BreakStatement();
            return new CaseNodeStatement(exp, body, @break);
        }

        private BreakNodeStatement BreakStatement()
        {
            if (_currentToken.Type == TokenType.RwBreak)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.EndStatement)
                    throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new BreakNodeStatement();
            }
            else
            {
                return null;
            }
        }

        private ExpressionNode SwitchLables()
        {
            if (_currentToken.Type == TokenType.RwCase)
            {
                _currentToken = _lexer.GetNextToken();
                var exp = Expresion();
                if (_currentToken.Type != TokenType.Colon)
                    throw new SintacticalException("Expected : Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return exp;
            }
            else
            {
                throw new SintacticalException("Expected Case or Default Line " + _currentToken.Line + " Col " +
                                                _currentToken.Column);
            }
        }

        private StatementNode DoStatement()
        {
            if (_currentToken.Type != TokenType.RwDo)
                throw new SintacticalException("Expected Do Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list = EmbededStatement();
            if (_currentToken.Type != TokenType.RwWhile)
                throw new SintacticalException("Expected while Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var condition = Expresion();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();

            if (_currentToken.Type != TokenType.EndStatement)
                throw new SintacticalException("Expected ; Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            return new DoWhileNodeStatement(condition, list);

        }

        private StatementNode WhileStatement()
        {
            if (_currentToken.Type != TokenType.RwWhile)
                throw new SintacticalException("Expected While Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();

            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var condition = Expresion();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var list = EmbededStatement();
            return new WhileNodeStatement(condition, list);
        }

        private IfNodeStatement IfStatement()
        {
            if (_currentToken.Type != TokenType.RwIf)
                throw new SintacticalException("Expected If Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();

            if (_currentToken.Type != TokenType.ParOpen)
                throw new SintacticalException("Expected ( Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var condition = Expresion();
            if (_currentToken.Type != TokenType.ParClose)
                throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            var trueStatements = EmbededStatement();

            if (_currentToken.Type == TokenType.RwElse)
            {
                _currentToken = _lexer.GetNextToken();
                var falseStatements = EmbededStatement();
                return new IfNodeStatement(condition, trueStatements, falseStatements);
            }
            else
            {
                return new IfNodeStatement(condition, trueStatements);
            }

        }

        private List<StatementNode> EmbededStatement()
        {
            if (_currentToken.Type == TokenType.KeyOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var list = StatementList();
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return list;
            }
            else if (_currentToken.Type.IsStatements())
            {
                var x = Statement();
                var list = new List<StatementNode>();
                list.Add(x);
                return list;
            }
            else
            {
                throw new SintacticalException("Expected { or Statement Line " + _currentToken.Line + " Col " +
                                                  _currentToken.Column);
            }
        }

        private ExpressionNode Expresion()
        {
            return ConditionalExpression();
        }

        private ExpressionNode ConditionalExpression()
        {
            var condition = NullCoalescingExpression();
            return Ternary(condition);
        }

        private ExpressionNode Ternary(ExpressionNode condition)
        {
            if (_currentToken.Type == TokenType.OpTernario)
            {
                _currentToken = _lexer.GetNextToken();
                var @true = Expresion();
                if (_currentToken.Type != TokenType.Colon)
                    throw new SintacticalException("Expected : Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var @false = Expresion();
                return new TeranryExpressionNode { Condition = condition, TrueExpression = @true, FalseExpression = @false };
            }
            else
            {
                return condition;
            }
        }

        private ExpressionNode NullCoalescingExpression()
        {
            var left = ConditionalOrExpression();
            return NullCoalescingExpressionPrime(left);
        }

        private ExpressionNode NullCoalescingExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpCoalescing)
            {
                _currentToken = _lexer.GetNextToken();
                var right = NullCoalescingExpression();
                return new CoalescingExpressionNode(param, right);
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode ConditionalOrExpression()
        {
            var left = ConditionalAndExpression();
            return ConditionalOrExpressionPrime(left);
        }

        private ExpressionNode ConditionalOrExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpLogicalOr)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ConditionalAndExpression();
                return ConditionalOrExpressionPrime(new LogicalOrExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode ConditionalAndExpression()
        {
            var left = InclusiveOrExpression();
            return ConditionalAndExpressionPrime(left);
        }

        private ExpressionNode ConditionalAndExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpLogicalAnd)
            {
                _currentToken = _lexer.GetNextToken();
                var right = InclusiveOrExpression();
                return ConditionalAndExpressionPrime(new LogicalAndExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode InclusiveOrExpression()
        {
            var left = ExclusiveOrExpression();
            return InclusiveOrExpressionPrime(left);
        }

        private ExpressionNode InclusiveOrExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpBinaryOr)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ExclusiveOrExpression();
                return InclusiveOrExpressionPrime(new BitOrExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode ExclusiveOrExpression()
        {
            var left = AndExpression();
            return ExclusiveOrExpressionPrime(left);
        }

        private ExpressionNode ExclusiveOrExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpBinaryXor)
            {
                _currentToken = _lexer.GetNextToken();
                var right = AndExpression();
                return ExclusiveOrExpressionPrime(new BitXorExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode AndExpression()
        {
            var left = EqualityExpression();
            return AndExpressionPrime(left);
        }

        private ExpressionNode AndExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpLogicalAnd)
            {
                _currentToken = _lexer.GetNextToken();
                var right = EqualityExpression();
                return AndExpressionPrime(new BitAndExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode EqualityExpression()
        {
            var left = RelationalExpresion();
            return EqualityExpressionPrime(left);
        }

        private ExpressionNode EqualityExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpEquals)
            {
                _currentToken = _lexer.GetNextToken();
                var right = RelationalExpresion();
                return EqualityExpressionPrime(new EqualExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpNotEquals)
            {
                _currentToken = _lexer.GetNextToken();
                var right = RelationalExpresion();
                return EqualityExpressionPrime(new NotEqualExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode RelationalExpresion()
        {
            var left = ShiftExpression();
            return RelationalExpresionPrime(left);
        }

        private ExpressionNode RelationalExpresionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpLessThan)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ShiftExpression();
                return RelationalExpresionPrime(new LessThanExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpGrtThan)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ShiftExpression();
                return RelationalExpresionPrime(new GreaterThanExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpLessThanOrEqual)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ShiftExpression();
                return RelationalExpresionPrime(new LessThanOrEqualExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpGrtThanOrEqual)
            {
                _currentToken = _lexer.GetNextToken();
                var right = ShiftExpression();
                return RelationalExpresionPrime(new GreaterThanOrEqualExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.RwAs)
            {
                _currentToken = _lexer.GetNextToken();
                var right = TypeProduction();
                return RelationalExpresionPrime(new AsExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.RwIs)
            {
                _currentToken = _lexer.GetNextToken();
                var right = TypeProduction();
                return RelationalExpresionPrime(new IsExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode ShiftExpression()
        {
            var left = AdditiveExpression();
            return ShiftExpressionPrime(left);
        }

        private ExpressionNode ShiftExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpRghtShft)
            {
                _currentToken = _lexer.GetNextToken();
                var right = AdditiveExpression();
                return ShiftExpressionPrime(new RightShiftExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpLftShft)
            {
                _currentToken = _lexer.GetNextToken();
                var right = AdditiveExpression();
                return ShiftExpressionPrime(new LeftShiftExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode AdditiveExpression()
        {
            var left = MultiplicativeExpression();
            return AdditiveExpressionPrime(left);
        }

        private ExpressionNode AdditiveExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpSum)
            {
                _currentToken = _lexer.GetNextToken();
                var right = MultiplicativeExpression();
                return AdditiveExpressionPrime(new SumExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpSub)
            {
                _currentToken = _lexer.GetNextToken();
                var right = MultiplicativeExpression();
                return AdditiveExpressionPrime(new SubExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private ExpressionNode MultiplicativeExpression()
        {
            var unary = UnaryExpression();
            var left = PrimaryExpression();
            left.UnaryNode = unary;
            return MultiplicativeExpressionPrime(left);
        }

        private ExpressionNode MultiplicativeExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.OpMul)
            {
                _currentToken = _lexer.GetNextToken();
                var unary = UnaryExpression();
                var right = PrimaryExpression();
                right.UnaryNode = unary;
                return MultiplicativeExpressionPrime(new MultExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpDiv)
            {
                _currentToken = _lexer.GetNextToken();
                var unary = UnaryExpression();
                var right = PrimaryExpression();
                right.UnaryNode = unary;
                return MultiplicativeExpressionPrime(new DivExpressionNode(param, right));
            }
            else if (_currentToken.Type == TokenType.OpMod)
            {
                _currentToken = _lexer.GetNextToken();
                var unary = UnaryExpression();
                var right = PrimaryExpression();
                right.UnaryNode = unary;
                return MultiplicativeExpressionPrime(new ModExpressionNode(param, right));
            }
            else
            {
                return param;
            }
        }

        private UnaryExpressionNode UnaryExpression()
        {
            if (_currentToken.Type == TokenType.OpSum)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new SumUnaryExpressionNode(unary);
            }
            else if (_currentToken.Type == TokenType.OpSub)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new SubUnaryExpressionNode(unary);
            }
            else if (_currentToken.Type == TokenType.OpLogicalNot)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new NotUnaryExpressionNode(unary);
            }
            else if (_currentToken.Type == TokenType.OpBinaryComplement)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new ComplementUnaryExpressionNode(unary);
            }
            else if (_currentToken.Type == TokenType.OpInc)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new IncUnaryExpressionNode(unary);
            }
            else if (_currentToken.Type == TokenType.OpDec)
            {
                var unary = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new DecUnaryExpressionNode(unary);
            }
            else
            {
                return null;
            }
        }
        private ExpressionNode PrimaryExpression()
        {
            if (_currentToken.Type == TokenType.RwNew)
            {
                _currentToken = _lexer.GetNextToken();
                 return ArrayOrObject();
            }
            else if (_currentToken.Type.IsPrimaryNoArrayCreationExpression())
            {
                return PrimaryNoArrayCreationExpression();
            }
            else if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                return CastOrExpression();
            }
            else
            {
                throw new SintacticalException("Expected valid Primary Expression Line " + _currentToken.Line +
                                               " Col " +
                                               _currentToken.Column);
            }
        }

        private AccesorExpressionNode IdExpression()
        {
            if (_currentToken.Type == TokenType.Period)
            {
                var idlexeme =_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor=IdExpression();
                if (accessor != null)
                    accessor.ParentId = idlexeme.Lexeme;
                return new PeriodAccessor { ParentId=idlexeme.Lexeme, Accessor= accessor };
            }
            else if (_currentToken.Type == TokenType.BraOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var expresionl=ExpresionList();
                if (_currentToken.Type != TokenType.BraClose)
                    throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor=IdExpression();
                return new BracketAccessor { expresionList = expresionl, Accessor = accessor };
            }
            else if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                var expresionl=ArgumentList();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor=ParentesisExpression();
                return new ParentesisAccessor { Accessor = accessor, expresionList = expresionl };

            }
            else
            {
                return null;
            }
        }

        private AccesorExpressionNode ParentesisExpression()
        {
            if (_currentToken.Type == TokenType.Period)
            {
				var idlexeme = _currentToken = _lexer.GetNextToken();
				if (_currentToken.Type != TokenType.Id)
					throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
												   _currentToken.Column);
				_currentToken = _lexer.GetNextToken();
				var accessor = IdExpression();
				if (accessor != null)
					accessor.ParentId = idlexeme.Lexeme;
				return new PeriodAccessor { ParentId = idlexeme.Lexeme, Accessor = accessor };
            }
            else if (_currentToken.Type == TokenType.BraOpen)
            {
				_currentToken = _lexer.GetNextToken();
				var expresionl = ExpresionList();
				if (_currentToken.Type != TokenType.BraClose)
					throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
												   _currentToken.Column);
				_currentToken = _lexer.GetNextToken();
				var accessor = IdExpression();
				return new BracketAccessor { expresionList = expresionl, Accessor = accessor };
            }
            else
            {
                return null;
            }
        }

        private NewExpressionNode ArrayOrObject()
        {
            if (_currentToken.Type.IsType())
            {
                TypeProductionForArrayOrObject();
                ArrayOrObjectPrime();
                IdExpression();
            }
            else if (_currentToken.Type == TokenType.BraOpen)
            {
                var rankspecifier=RankSpecifier();
                var arraynode=ArrayInitalizer();
                return new NewArrayInitalizerNode { RankSpecifer = rankspecifier,ArrayInitalizerNode  = arraynode};
            }
            else
            {
                throw new SintacticalException("Expected type or [  Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private void ArrayOrObjectPrime()
        {
            if (_currentToken.Type == TokenType.BraOpen)
            {
                ArrayCreationExpression();
            }
            else if (_currentToken.Type == TokenType.ParOpen || _currentToken.Type == TokenType.KeyOpen)
            {
                ObjectCreationExpression();
            }
            else
            {
                throw new SintacticalException("Expected (, { or [  Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private void ArrayCreationExpression()
        {
            if (_currentToken.Type != TokenType.BraOpen)
                throw new SintacticalException("Expected [ Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            PostArrayCreationExpression();
        }

        private void PostArrayCreationExpression()
        {
            if (_currentToken.Type.IsExpression())
            {
                ExpresionList();
                if (_currentToken.Type != TokenType.BraClose)
                    throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.BraOpen)
                    RankSpecifiers();
                if (_currentToken.Type == TokenType.KeyOpen)
                    ArrayInitalizer();
            }
            else
            {
                DimSpearetorsOpt();
                if (_currentToken.Type != TokenType.BraClose)
                    throw new SintacticalException("Expected ] Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                RankSpecifiersPrime();
                ArrayInitalizer();
            }
        }

        private void ObjectCreationExpression()
        {
            if (_currentToken.Type == TokenType.ParOpen)
            {
                _currentToken = _lexer.GetNextToken();
                ArgumentList();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                ObjectCollectionInitalizerOpt();
            }
            else if (_currentToken.Type == TokenType.KeyOpen)
            {
                ObjectCollectionInitalizer();
            }
        }

        private void ObjectCollectionInitalizerOpt()
        {
            if (_currentToken.Type == TokenType.KeyOpen)
            {
                ObjectCollectionInitalizer();
            }
            else
            {

            }
        }

        private void ObjectCollectionInitalizer()
        {
            if (_currentToken.Type == TokenType.KeyOpen)
            {
                _currentToken = _lexer.GetNextToken();
                ObjectCollectionInitalizerBody();
            }
            else
            {
                throw new SintacticalException("Expected { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private void ObjectCollectionInitalizerBody()
        {
            if (_currentToken.Type == TokenType.Id)
            {
                MemberOrElement();
            }
            else
            {
                ElementInitalizerList();
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }
        }

        private void MemberOrElement()
        {
            if (_currentToken.Type == TokenType.Id)
            {
                _currentToken = _lexer.GetNextToken();
                MemberInitalizerList();
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type.IsExpression() || _currentToken.Type == TokenType.ParOpen)
            {
                ElementInitalizerList();
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
            }
        }

        private void MemberInitalizerListOpt()
        {
            if (_currentToken.Type == TokenType.OpAsgn)
            {
                MemberInitalizerList();
            }
            else
            {

            }
        }

        private void MemberInitalizerList()
        {
            MemberInitalizer();
            MemberInitalizerListPrime();
        }

        private void MemberInitalizerListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                       _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                MemberInitalizer();
                MemberInitalizerListPrime();
            }
            else
            {

            }
        }

        private void MemberInitalizer()
        {
            if (_currentToken.Type != TokenType.OpAsgn)
                throw new SintacticalException("Expected = Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            _currentToken = _lexer.GetNextToken();
            InitalizerValue();
        }

        private void InitalizerValue()
        {
            if (_currentToken.Type.IsExpression())
            {
                Expresion();
            }
            else if (_currentToken.Type == TokenType.KeyOpen)
            {
                ObjectCollectionInitalizer();
            }
            else
            {
                throw new SintacticalException("Expected Expression or { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private void ElementInitalizerList()
        {
            ElementInitalizer();
            ElementInitalizerListPrime();
        }

        private void ElementInitalizerListPrime()
        {
            if (_currentToken.Type == TokenType.Comma)
            {
                _currentToken = _lexer.GetNextToken();
                ElementInitalizer();
                ElementInitalizerListPrime();
            }
            else
            {

            }
        }

        private void ElementInitalizer()
        {
            if (_currentToken.Type.IsExpression())
            {
                Expresion();
            }
            else if (_currentToken.Type == TokenType.KeyOpen)
            {
                _currentToken = _lexer.GetNextToken();
                ExpresionList();
                if (_currentToken.Type != TokenType.KeyClose)
                    throw new SintacticalException("Expected } Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();

            }
            else
            {
                throw new SintacticalException("Expected Expresion or { Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }


        private ExpressionNode CastOrExpression()
        {
            if (_currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum)
            {
                var t=CustomTypeProduction();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var p=PrimaryExpression();
                return new CastExpressionNode {Left = t,Right = p};

            }
            else if (_currentToken.Type.IsExpression())
            {
                var exp=Expresion();
                if (_currentToken.Type != TokenType.ParClose)
                    throw new SintacticalException("Expected ) Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return CastOrExpressionPrime(exp);
            }
            else
            {
                throw new SintacticalException("Expected primitive type or Expression Line " + _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private ExpressionNode CastOrExpressionPrime(ExpressionNode exp)
        {
            if (_currentToken.Type.IsPrimaryExpression())
            {
                var p= PrimaryExpression();
                return new CastExpressionNode {Left = exp, Right = exp};
            }
            else if (_currentToken.Type == TokenType.Period || _currentToken.Type == TokenType.ParOpen || _currentToken.Type == TokenType.BraOpen)
            {

                var accessor= IdExpression();
                return new ParentesisExpresionNode {ExpresioNode = exp,AccesorExpression = accessor};

            }
            else
            {
                return exp;
            }
        }

        private PrimaryExpressionNode PrimaryNoArrayCreationExpression()
        {

            if (_currentToken.Type == TokenType.LitBool)
            {
                var lit = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new BoolLiteralExpressionNode(bool.Parse(lit));
            }
            if (_currentToken.Type == TokenType.LitChar)
            {
                var lit = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new CharLiteralExpressionNode(char.Parse(lit));
            }
            if (_currentToken.Type == TokenType.LitNum)
            {
                var lit = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                int number = 0;
                if (lit.Contains("0x") || lit.Contains("0X"))
                {
                    number = Convert.ToInt32(lit, 16);
                }
                else if (lit.Contains("0b") || lit.Contains("0B"))
                {
                    lit = lit.Substring(2);
                    number = Convert.ToInt32(lit, 2);
                }
                else
                {
                    number = int.Parse(lit);
                }
                return new IntLiteralExpressionNode(number);
            }
            if (_currentToken.Type == TokenType.LitFloat)
            {
                var lit = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();

                if (lit.Contains("f") || lit.Contains("F"))
                {
                    lit=lit.Remove(lit.Length - 1);
                }

                return new FloatLiteralExpressionNode(float.Parse(lit));
            }
            if (_currentToken.Type == TokenType.LitString)
            {
                var lit = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new StringLiteralExpressionNode(lit);
            }
            if (_currentToken.Type == TokenType.RwThis || _currentToken.Type == TokenType.RwBase || _currentToken.Type == TokenType.Id)
            {
                var preIdNode = PreIdExpression();
                var name = _currentToken.Lexeme;
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor = IdExpression();
                var idLeft= new IdLeftExpressionNode(preIdNode,new IdTypeNode(name,null), accessor);
                var assgnExp = AssignmentInExpression(idLeft);
                var postId = PostIncrementExpression();
                return new IdExpressionNode(idLeft, assgnExp, postId);

            }
            if (_currentToken.Type.IsPredifinedType() || _currentToken.Type == TokenType.RwEnum)
            {
                var temp = _currentToken.Type;
                PrimitiveTypeNode primitiveNode = null;
                if (temp == TokenType.RwBool)
                {
                    primitiveNode = new PrimitiveBoolNode();
                }
                if (temp == TokenType.RwChar)
                {
                    primitiveNode = new PrimitiveCharNode();
                }
                if (temp == TokenType.RwInt)
                {
                    primitiveNode = new PrimitiveIntNode();
                }
                if (temp == TokenType.RwFloat)
                {
                    primitiveNode = new PrimitiveFloatNode();
                }
                if (temp == TokenType.RwString)
                {
                    primitiveNode = new PrimitiveStringNode();
                }
                if (temp == TokenType.RwEnum)
                {
                    primitiveNode = new PrimitiveEnumNode();
                }
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Period)
                    throw new SintacticalException("Expected . Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                var name=_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Id)
                    throw new SintacticalException("Expected Id Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                var accessor = IdExpression();
                var post = PostIncrementExpression();
                return new PrimitiveTypeExpressionNode(primitiveNode, name.Lexeme, accessor, post);
            }
            else
            {
                throw new SintacticalException("Expected Primary No Array Creation Expression Line " +
                                               _currentToken.Line + " Col " +
                                               _currentToken.Column);
            }
        }

        private AssignationExpressionNode AssignmentInExpression(IdLeftExpressionNode left)
        {

            if (_currentToken.Type == TokenType.OpAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationEqualExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpAddAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationSumExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpSubAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationSubExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpMulAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationMultExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpDivAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationDivExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpModAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationModExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpAndAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationAndExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpOrAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationOrExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpXorAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationXorExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpLftShftAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationLftShftExpressionNode(left, right);
            }
            if (_currentToken.Type == TokenType.OpRghtShftAsgn)
            {
                var right = Expresion();
                _currentToken = _lexer.GetNextToken();
                return new AssignationRghtShftExpressionNode(left, right);
            }
            else
            {
                return null;
            }
        }

        private PreIdExpressionNode PreIdExpression()
        {
            if (_currentToken.Type == TokenType.RwThis)
            {
                var @this = _currentToken;
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Period)
                    throw new SintacticalException("Expected . Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new ThisExpressionNode();
            }
            else if (_currentToken.Type == TokenType.RwBase)
            {
                var @base = _currentToken;
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.Period)
                    throw new SintacticalException("Expected . Line " + _currentToken.Line + " Col " +
                                                   _currentToken.Column);
                _currentToken = _lexer.GetNextToken();
                return new BaseExpressionNode();
            }
            else
            {
                return null;
            }
        }

        private PostIdExpressionNode PostIncrementExpression()
        {
            if (_currentToken.Type == TokenType.OpInc)
            {
                _currentToken = _lexer.GetNextToken();
                return new IncNode();
            }
            else if (_currentToken.Type == TokenType.OpDec)
            {
                _currentToken = _lexer.GetNextToken();
                return new DecNode();
            }
            else
            {
                return null;
            }
        }
    }
}