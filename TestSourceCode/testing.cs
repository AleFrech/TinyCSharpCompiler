using LexerProject;
using LexerProject.Tokens;
using ParserProject.Exceptions;


namespace mierda.mierda
{
   using LexerProject;

   namespace tucu
   {
      using LexerProject;

      public class Mierda : IMierda,ITucu
      {
        
      }


      private static class Tucu : Mierda
      {
        protected static  string Name
            {
                private get;
                set;
            }
         

         private static char label;
         public static int c=1,d=2;

         private static Tucu(){

         }

         public static void DoShit(int x, string y){
             
         }

         protected static int DoMoreShit(float x, Mierda mierda){

         }
        
      }

      public interface IName:IMierda,System.ITest
      {
            string Name
            {
                private get;
                set;
            }

            int Counter
            {
                protected get;
            }

         bool[,][,][,][,][,][,][,] Equals(T obj,int param);
         void MethodToImplement();
      }

      public enum tortas
      {
            DeZuma,
            DeZuHelma=2,
            DeZuTia=3
      }

   }
}