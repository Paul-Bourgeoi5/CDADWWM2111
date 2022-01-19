using System;

namespace Exercice3PoupeeRusse
{
    class Program
    {
        static void Main(string[] args)
        {
            PoupeeRusse petitePoupee = new PoupeeRusse(1);
            PoupeeRusse moyennePoupee = new PoupeeRusse(5);
            PoupeeRusse grandePoupee = new PoupeeRusse(50);
            PoupeeRusse tresGrande = new PoupeeRusse(55);

            petitePoupee.PlacerDans(moyennePoupee);
            moyennePoupee.Ouvrir();
            petitePoupee.PlacerDans(moyennePoupee);
            moyennePoupee.Fermer();
            petitePoupee.Ouvrir();
            grandePoupee.Ouvrir();
            moyennePoupee.PlacerDans(grandePoupee);

            petitePoupee.SortirDe(grandePoupee);
            moyennePoupee.PlacerDans(grandePoupee);
            grandePoupee.Fermer();
            tresGrande.Ouvrir();
            grandePoupee.PlacerDans(tresGrande);
            tresGrande.Fermer();

            Console.WriteLine($"Nombre de poupées emboitées : {PoupeeRusse.CompterLesPoupeesEmboitees(tresGrande)}");
        }


        
    }
}
