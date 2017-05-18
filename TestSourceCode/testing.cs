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


    private  class Tucu : Mierda
      {
        protected static  string Name
            {
                private get;
                set;
            }
         
           private  string Name2
            {
                private get;
                set;
            }
         

         private static char label;
         public static int c=1,d=2;

         private  char label2;
         public  int c2=1,d2=6;


         private static Tucu(){

         }

         private Tucu(int x){

         }

          private Tucu(int x,int y){

         }

         public static void DoShit(int x, string y){
            
         }

         private override float[][,] DoShit2(int x, string y){
             
         }

         protected static int[][,,,]  DoMoreShit(float x, Mierda mierda){

         }

         protected  int[][,,,]  DoMoreShit2(float x, Mierda mierda){
            int x=1,y=2,z=1=2;
            var z=10f;
            if(1>5){
               while(2){

               }
               return 5; 
               ;
              }
              do{
                foreach(var x in 5){
                  break;
                }
              }while(1);

              switch(5){
                  case: if(1<5)
                            return 5;
                        break;
                  default:
              }


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