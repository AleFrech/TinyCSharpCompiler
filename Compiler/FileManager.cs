﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using LexerProject;
using ParserProject;
using ParserProject.Nodes.NameSpaceNodes;

namespace Compiler
{
    public class FileManager
    {
        private string systemClasses;
        private string predefinedFunctions;
        public FileManager()
        {
            this.systemClasses  = @"namespace System {
                    public class Object{
                        
                        public virtual string ToString(){
                                return """";
                       }
                    }
                    public class int {
                        public static int Parse(){
                            return 1;    
                        }
                    }
                     public class float {
                        public static float Parse(){
                            return 0.5f;    
                        }
                    }
                   public class string {

                    }
                    public class Console {
                        public static WriteLine(){

                        }

                        public static ReadLine(){

                        }
                    }
                }";

            this.predefinedFunctions = @"function decimalToBinary(decimal) {
  return (decimal >>> 0).toString(); 
}

function getBoolBitAndValue(a,b) {
    const c= a & b;
    return c==0 ? false : true ;
}

function getBoolBitOrValue(a,b) {
    const c= a | b;
    return c==0 ? false : true ;
}

function getBoolBitXorValue(a,b) {
    const c= a ^ b;
    return c==0 ? false : true ;
}

function getIntBitAndValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  const binC = decimalToBinary(decC);
  const binI = decimalToBinary(decI);
  return binC & binI;
  
}

function getIntBitOrValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  const binC = decimalToBinary(decC);
  const binI = decimalToBinary(decI);
  return binC | binI;
  
}

function getIntBitOrValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  const binC = decimalToBinary(decC);
  const binI = decimalToBinary(decI);
  return binC ^ binI;

function getIntDivValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return parseInt(decC / decI,10);
  
}

function getIntModValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return parseInt(decC % decI,10);
  
}

function getIntMultValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return parseInt(decC * decI,10);
  
}

function getFloatDivValue(c, i) {
  let cValue;
  let iValue;
  
  if(!isNaN(parseFloat(c))){
    cValue=parseFloat(c);
  }else{
    cValue=c.charCodeAt(0);
  }
  
  if(!isNaN(parseFloat(i))){
    iValue=parseFloat(i);
  }else{
    iValue=i.charCodeAt(0);
  }
  return parseFloat(cValue/iValue);
}

function getFloatModValue(c, i) {
  let cValue;
  let iValue;
  
  if(!isNaN(parseFloat(c))){
    cValue=parseFloat(c);
  }else{
    cValue=c.charCodeAt(0);
  }
  
  if(!isNaN(parseFloat(i))){
    iValue=parseFloat(i);
  }else{
    iValue=i.charCodeAt(0);
  }
  return parseFloat(cValue%iValue);
}

function getFloatMultValue(c, i) {
  let cValue;
  let iValue;
  
  if(!isNaN(parseFloat(c))){
    cValue=parseFloat(c);
  }else{
    cValue=c.charCodeAt(0);
  }
  
  if(!isNaN(parseFloat(i))){
    iValue=parseFloat(i);
  }else{
    iValue=i.charCodeAt(0);
  }
  return parseFloat(cValue*iValue);
}


function getFloatSumValue(c, i) {
  let cValue;
  let iValue;
  
  if(!isNaN(parseFloat(c))){
    cValue=parseFloat(c);
  }else{
    cValue=c.charCodeAt(0);
  }
  
  if(!isNaN(parseFloat(i))){
    iValue=parseFloat(i);
  }else{
    iValue=i.charCodeAt(0);
  }
  return parseFloat(cValue+iValue);
}

function getFloatSubValue(c, i) {
  let cValue;
  let iValue;
  
  if(!isNaN(parseFloat(c))){
    cValue=parseFloat(c);
  }else{
    cValue=c.charCodeAt(0);
  }
  
  if(!isNaN(parseFloat(i))){
    iValue=parseFloat(i);
  }else{
    iValue=i.charCodeAt(0);
  }
  return parseFloat(cValue-iValue);
}


function getIntLeftShiftValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return decC << decI;
  
}

function getIntRightShiftValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return decC >>> decI;
  
}




";

        }

        public string GetSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
        }




        public List<List<CodeNode>> GetTreeListFromFiles()
        {
            var files = Directory.GetFiles("./TestProject", "*.cs", SearchOption.AllDirectories);
            var treeList= new List<List<CodeNode>>();
            foreach (var file in files)
            {
                
                var lex = new Lexer(new InputString(File.ReadAllText(file)));
                var parser = new Parser(lex);
                var tree = parser.Parse();
                treeList.Add(tree);
                
            }

            treeList.Add(new Parser(new Lexer(new InputString(systemClasses))).Parse());

            return treeList;
        }


        public void WriteXml(List<CodeNode> tree){
			const string assemblyName = "ParserProject";
			var types = Assembly.Load(new AssemblyName(assemblyName))
								.GetTypes().Where(type => type.GetTypeInfo().IsPublic)
								.Where(type => !type.Name.EndsWith("TokenTypeExtensions", StringComparison.Ordinal) &&
									   !type.Name.EndsWith("SintacticalException", StringComparison.Ordinal));
            
			XmlSerializer serialializer = new XmlSerializer(tree.GetType(), types.ToArray());

			StreamWriter writer = new StreamWriter(File.Create(Path.Combine(AppContext.BaseDirectory.
																		  Substring(0, AppContext.BaseDirectory.IndexOf("Compiler", StringComparison.Ordinal)), "TestSourceCode/output.xml")));
			serialializer.Serialize(writer, tree);
        }
    }
}
