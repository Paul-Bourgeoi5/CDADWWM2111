using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    class StyloPlume : OutilEcriture
    {
        public StyloPlume()
        {
            this.Couleur = "vert";
            this.CapaciteEcriture = 100;
        }

        public StyloPlume(string couleur)
        {
            this.Couleur = couleur;
            this.CapaciteEcriture = 100;
        }

        public void RemplacerCartouche(string couleur)
        {
            this.Couleur = couleur;
            this.CapaciteEcriture = 100;
        }

        public override void Utiliser()
        {
            this.Ecrire();
            this.CapaciteEcriture -= 2;
        }


    }
}
