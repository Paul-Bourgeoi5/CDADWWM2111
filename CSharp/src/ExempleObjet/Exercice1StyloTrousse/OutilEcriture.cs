using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    abstract class OutilEcriture : IOutil
    {
        private int _capaciteEcriture;
        private string _couleur;

        public int CapaciteEcriture 
        {
            get { return _capaciteEcriture; } 
            protected set { _capaciteEcriture = value; } 
        }

        public string Couleur
        {
            get {return _couleur ; }
            protected set { _couleur = value ; }
        }

        /// <summary>
        /// Écrit du texte s'il reste de la capacité d'écriture.
        /// </summary>
        protected void Ecrire() 
        {
            if (this.CapaciteEcriture > 0)
            {
                Console.WriteLine($"J'écris du texte de couleur {Couleur}");
            }
            else
            {
                Console.WriteLine("!!! Capacité d'écriture épuisée !!!");
            }
        }

        /// <summary>
        /// Utilisation d'un outil d'écriture en écrivant.
        /// </summary>
        public abstract void Utiliser();
    }
}
