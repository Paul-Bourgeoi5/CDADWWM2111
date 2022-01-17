using System;

namespace Exercice1StyloTrousse
{
    class Program
    {
        static void Main(string[] args)
        {
            CrayonDeCouleur crayonVert = new("vert");
            crayonVert.Utiliser();
            crayonVert.Utiliser();
            crayonVert.Utiliser();
            crayonVert.Utiliser();
            CrayonDeCouleur crayonVert2 = new("vert");
            StyloPlume styloPlumeBleu = new("bleu");
            StyloBille styloBilleRouge = new("rouge");

            TrousseScolaire maTrousse = new TrousseScolaire(2);

            maTrousse.Ouvrir();
            maTrousse.RangerAffaire(crayonVert);
            maTrousse.RangerAffaire(crayonVert2);


            Console.WriteLine(maTrousse.GetAllAffaires());


        }
    }
}
