using System;

namespace CdaExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;

            
            try
            {
                //age = int.Parse("31212121212154546546465465446465");
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("La boulangerie, c'est au sous sol !");
            }
            catch(Exception e)
            {
                Console.WriteLine("Une erreur est survenue");
            }




            try
            {
                // ouverture d'un fichier
                age = int.Parse("jhgjk");
                Console.WriteLine("ici le try");
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue");
            }
            finally
            {
                Console.WriteLine("Ici c'est fini !");
                // fermeture du fichier
            }


        }
    }
}
