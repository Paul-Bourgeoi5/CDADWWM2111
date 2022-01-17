using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    abstract class Trousse
    {
        private int _nombreOutilsMax;
        private bool _estOuverte;

        public Trousse(int nombreOutilsMax)
        {
            this.NombreOutilsMax = nombreOutilsMax;
            this.EstOuverte = false;
        }

        public int NombreOutilsMax
        {
            get { return _nombreOutilsMax; }
            init { _nombreOutilsMax = value; }
        }



        public bool EstOuverte
        {
            get { return _estOuverte; }
            private set { _estOuverte = value; }
        }

        public void Ouvrir()
        {
            if (!this.EstOuverte)
            {
                EstOuverte = true;
            }
        }

        public void Fermer()
        {
            if (this.EstOuverte)
            {
                EstOuverte = false;
            }
        }

    }
}
