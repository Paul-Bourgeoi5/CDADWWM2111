using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    class VoitureBasique
    {
        private string _couleur;

        public string Couleur
        {
            get { return _couleur; }
            set { _couleur = value.ToLower(); }
        }

        private bool _moteur;

        public bool Moteur
        {
            get => _moteur;
            set => _moteur = value;
        }

        public VoitureBasique()
        {
            Couleur = "bleu";
            Moteur = false;
        }

        public VoitureBasique(string couleur, bool moteur = false)
        {
            Couleur = couleur;
            Moteur = moteur;
        }

        public void Demarer()
        {
            this.Moteur = true;
        }

        public void Eteindre()
        {
            this.Moteur = false;
        }

        public override string ToString()
        {
            return ($"La voiture est {Couleur} et allumée : {Moteur}");
        }

    }
}
