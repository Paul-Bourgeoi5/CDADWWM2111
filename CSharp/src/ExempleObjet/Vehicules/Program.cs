using System;

namespace Vehicules
{
    class Program
    {
        static void Main(string[] args)
        {
            VoitureBasique voiture = new VoitureBasique();


            VoitureBasique voitureVerte = new VoitureBasique("vert");


            VoitureBasique voitureViolette = new VoitureBasique("violet", true);

            Console.WriteLine(voitureVerte.ToString());
            Console.WriteLine(voiture.ToString());
            Console.WriteLine(voitureViolette.ToString());

            voitureViolette.Eteindre();
            voiture.Demarer();

            Console.WriteLine("\n\n" + voitureVerte.ToString());
            Console.WriteLine(voiture.ToString());
            Console.WriteLine(voitureViolette.ToString());

        }
    }
}
