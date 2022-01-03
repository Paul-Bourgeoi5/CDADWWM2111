using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    class Voiture
    {
        private string _couleur;
        private int _poids;
        private int _puissance;
        private int _reservoir;
        private int _vitesse;
        private bool _moteur;
        private int _jaugeEssence;

        public int JaugeEssence
        {
            get { return _jaugeEssence; }
            set 
            {
                if (value > Reservoir)
                {
                    _jaugeEssence = Reservoir;
                }
                else if (value < 0)
                {
                    _jaugeEssence = 0;
                }
                else
                {
                    _jaugeEssence = value;
                }
            }
        }

        public bool Moteur
        {
            get { return _moteur; }
            set { _moteur = value; }
        }

        private string _proprietaire;

        public string Proprietaire
        {
            get { return _proprietaire; }
            set { _proprietaire = value; }
        }

        public int Poids
        {
            get { return _poids; }
            set { _poids = value; }
        }

        public int Puissance
        {
            get { return _puissance; }
            set { _puissance = value; }
        }

        public int Reservoir
        {
            get { return _reservoir; }
            set { _reservoir = value; }
        }

        public int Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }


        public string Couleur {
            get { return _couleur ;}
            set { _couleur = value.ToLower() ;} 
        }
        /*
        public string getCouleur()
        {
            return this._couleur;
        }

        public void setCouleur(string nouvelleCouleur)
        {
            _couleur = nouvelleCouleur;
        }
        */

        public Voiture()
        {
            this.Couleur = "bleu";
            this.Vitesse = 0;
            this.Puissance = 12;
            this.Reservoir = 50;
            this.Poids = 979;
            this.Moteur = false;
            this.JaugeEssence = Reservoir;

        }

        public override string ToString()
        {
            StringBuilder result = new ();
            result.Append($"La voiture de {Proprietaire} est {Couleur}");
            result.Append($"\nLe poids est de {Poids}kg, la puissance est de {Puissance}CV avec un réservoir de {Reservoir}L et une vitesse actuelle de {Vitesse}km/h");
            result.Append($"\nLa voiture est allumée : {Moteur}\nLa jauge d'essence est pleine à {(float)JaugeEssence/(float)Reservoir*100f}%");
            return result.ToString();
        }

        public void Demarrer()
        {
            Moteur = true;
        }

        public void Deplacer()
        {
            if (Moteur && JaugeEssence > 0)
            {
                Vitesse = 50;
                JaugeEssence--;
            }

        }

        public void MettreEssence()
        {
            JaugeEssence = Reservoir;
        }

        public void Eteindre()
        {
            Moteur = false;
            Vitesse = 0;
        }

    }
}
