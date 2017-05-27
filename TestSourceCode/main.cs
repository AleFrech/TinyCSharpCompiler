using System;
using System.IO;
using LexerProject;
using LexerProject.Tokens;

 namespace Compiler
 {
     public enum Days { Sun=2+5, Mon, tue, Wed=4, thu, Fri, Sat }

     public interface ITransactions
    {
    // interface members
        void showTransaction();
        double getAmount(int x, Double salary);
        int getNum();
    }

    public class Name
    {
        
    }
     
 }