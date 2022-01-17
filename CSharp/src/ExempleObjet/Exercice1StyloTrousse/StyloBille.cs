using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    class StyloBille : OutilEcriture
    {


        public StyloBille()
        {
            this.Couleur = "rouge";
            this.CapaciteEcriture = 100;
        }

        public StyloBille(string couleur)
        {
            this.Couleur = couleur;
            this.CapaciteEcriture = 100;
        }


        public override void Utiliser()
        {
            this.Ecrire();
            this.CapaciteEcriture--;
        }

    }
}
