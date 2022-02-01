using System;

namespace ONF
{
    class Program
    {
        static void Main(string[] args)
        {
            Parcelle p1 = new Parcelle(1);
            Arbre a1 = new Arbre(
                diametre: 15,
                hauteur: 14,
                typeArbre: TypeArbre.RESINEUX,
                parcelle: p1);


            try
            {
                p1.AjouterArbre(a1);
            } catch (Exception error)
            {
                Console.Error.WriteLine(error.Message);
            }
        }
    }
}
