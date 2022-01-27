using System;

namespace SujetExamen
{
    class Program
    {
        static void Main(string[] args)
        {
            string monSujetComplet = "";
            QuestionAChoixMultiple robert = new("Poyurquoi ?", 95);
            QuestionAChoixMultiple larousse = new("whyyy ?", 10);

            robert.AjouterReponse(new Reponse("Faux la réponse n'est pas correcte, sisi je te jure", false));
            robert.AjouterReponse(new Reponse("Vrai la réponse est ok tu es le meilleur", true));


            Sujet monPremierSujet = new();
            /*robert.SupprimerReponse(new Reponse("Oui", true));*/

            monPremierSujet.AjouterQuestion(robert, 12);
            monPremierSujet.AjouterQuestion(larousse, 17);

            monSujetComplet = monPremierSujet.AfficherSujetComplet();

            Console.WriteLine(monSujetComplet);

        }
    }
}
