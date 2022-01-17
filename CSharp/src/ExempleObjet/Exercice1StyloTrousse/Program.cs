using System;

namespace Exercice1StyloTrousse
{
    class Program
    {
        static void Main(string[] args)
        {
            CrayonDeCouleur monCrayon = new();
            while (monCrayon.CapaciteEcriture > 0)
                monCrayon.Utiliser();
        }
    }
}
