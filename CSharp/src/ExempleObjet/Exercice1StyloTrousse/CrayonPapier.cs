using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    class CrayonPapier : Crayon
    {
        CrayonPapier()
        {
            this.CapaciteEcriture = 100;
            this.Couleur = "gris";
            this.PointeDeMineTaillee = true;
        }
    }
}
