using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    abstract class Crayon : OutilEcriture
    {
        private bool _pointeDeMineTaillee;

        public bool PointeDeMineTaillee
        {
            get { return this._pointeDeMineTaillee; }
            protected set { this._pointeDeMineTaillee = value;}
        }

        public void Tailler()
        {
            if (CapaciteEcriture > 3)
            {
                CapaciteEcriture -= 3;
                PointeDeMineTaillee = true;
            }
            else
            {
                CapaciteEcriture = -1;
            }
        }

        public override void Utiliser()
        {
            int rndMinePlusTaillee = new Random().Next(0, 3);

            if (!this.PointeDeMineTaillee)
            {
                this.Tailler();
            }
            base.Ecrire();

            if (rndMinePlusTaillee == 0)
            {
                this.PointeDeMineTaillee = false;
            }
        }
    }
}
