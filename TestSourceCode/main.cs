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

  public class Program
{
    static void Main()
    {
        int value = (int)1.5f; // Cast 1.
        Console.WriteLine(value);
        object val = 1;//new StringBuilder();
        if (val is StringBuilder) // Cast 2.
        {
             StringBuilder builder = val as StringBuilder; // Cast 3.
             Console.WriteLine(builder.Length == 0);
        }
    }
}
     
 }