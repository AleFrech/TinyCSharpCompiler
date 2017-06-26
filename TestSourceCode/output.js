
                    //let readlineSync = require('readline-sync');

	                    class System {
	                    }
                      System.object = class {

                        }

                        System.int = class {
                            static Parse(str){
                                return  parseInt(str, 10);    
                            }
                        }

                        System.float = class {
                            static Parse(str){
                                return  parseFloat(str);
                            }
                        }

                        System.Console = class {

                            static WriteLine(str){
                                console.log(str);
                            }

                            static ReadLine(){
                                return readlineSync.question();
                            }
                        }
   
                
function decimalToBinary(decimal) {
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
}

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

function getIntSumValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return parseInt(decC + decI,10);
  
}

function getIntSubValue(c, i) {
  const decC = typeof c === 'number' ? c : c.charCodeAt(0);
  const decI = typeof i === 'number' ? i : i.charCodeAt(0);
  return parseInt(decC - decI,10);
  
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





class Program {
_define() { 
}
constructor(  ) {
_define();
}
static  Main( ...args ) {
let methods ={
Main_1 : function ( args ) {
System.Console.WriteLine(( getIntRightShiftValue( 'a' , 1 ) ))
}
}
let name = "Main"+ "_" + args.length;
return methods[name](...args);
}
}


Program.Main('Program');
