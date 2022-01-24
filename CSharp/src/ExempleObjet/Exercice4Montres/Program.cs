using System;

namespace Exercice4Montres
{
    class Program
    {
        static void Main(string[] args)
        {
            var montre1 = new Montre(13, 45);
            Montre montre2 = new(montre1);
            // Console.WriteLine(montre1.AfficherHeure());

            for (int i = 1; i <= 15; i++)
            {
                montre1.AjouterMinute();
            }


            //Console.WriteLine(montre1.AfficherHeure());
            //Console.WriteLine(montre2.AfficherHeure());

            //Afficher l'heure à minuit
            var montre3 = new Montre(0, 0);
            //Console.WriteLine(montre3.AfficherHeure());

            // Instanciation de 3 personnes.
            Personne toto = new("Toto");
            Personne titi = new("Titi");
            var rosMinet = new Personne("GrosMinet");

            toto.MettreMontre(montre1);
            Console.WriteLine("Il est : " + titi.DemanderHeureA(toto));
            Console.WriteLine("Il est: " + toto.DemanderHeureA(toto));

            // rosMinet ne peut pas mettre la montre 1 déjà mise par toto.
            rosMinet.MettreMontre(montre1);
            Console.WriteLine(rosMinet.DemanderHeureA(rosMinet));
            // rosMinet met la montre2
            rosMinet.MettreMontre(montre2);
            Console.WriteLine(rosMinet.DemanderHeureA(rosMinet));
            toto.EnleverSaMontre();
            // titi met la montre1 que toto vient enlever
            titi.MettreMontre(montre1);
            Console.WriteLine(rosMinet.DemanderHeureA(titi));
            // titi essaie de mettre la montre3 mais il ne peut pas car il en a déjà une.
            titi.MettreMontre(montre3);
            Console.WriteLine(titi.DemanderHeureA(titi));
            toto.MettreMontre(montre3);
            Console.WriteLine(titi.DemanderHeureA(toto));
        }
        
    }
}
