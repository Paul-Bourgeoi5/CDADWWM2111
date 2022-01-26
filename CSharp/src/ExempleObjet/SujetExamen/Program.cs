using System;

namespace SujetExamen
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionAChoixMultiple robert = new("Poyurquoi ?", 95);
 
            robert.SupprimerReponse(new Reponse("Oui", true));

        }
    }
}
