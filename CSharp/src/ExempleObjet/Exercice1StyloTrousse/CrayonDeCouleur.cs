using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    class CrayonDeCouleur : Crayon
    {
        public CrayonDeCouleur()
        {
            this.Couleur = "bleu";
            this.CapaciteEcriture = 100;
            this.PointeDeMineTaillee = true;
        }

        public CrayonDeCouleur(string couleur)
        {
            this.Couleur = couleur;
            this.CapaciteEcriture = 100;
            this.PointeDeMineTaillee = true;
        }
    }
}
