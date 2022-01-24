using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4Montres
{
    class Montre
    {
        private int _heure;
        private int _minute;
        private Personne _personnePorteuse;

        /// <summary>
        /// Constructeur de montre avec en paramètres une heure et une minute.
        /// </summary>
        /// <param name="heure"></param>
        /// <param name="minute"></param>
        public Montre(int heure, int minute)
        {
            this.Heure = heure;
            this.Minute = minute;
            this._personnePorteuse = null;
        }

        /// <summary>
        /// Constructeur par recopie d'une autre montre.
        /// </summary>
        /// <param name="m"></param>
        public Montre(Montre m)
        {
            this.Heure = m.Heure;
            this.Minute = m.Minute;
            this._personnePorteuse = null;
        }

        public int Heure
        {
            get { return _heure; }
            private set 
            { 
                if (value >= 0 && value <= 23)
                    _heure = value; 
                else
                {
                    _heure = 0;
                }
            }
        }

        public int Minute
        {
            get { return _minute; }
            private set
            {
                if (value >= 0 && value <= 59)
                    _minute = value;
                else if (value > 59)
                {
                    this.Heure++;
                    _minute = 0;
                }
                else
                {
                    _minute = 0;
                }
            }
        }

        public Personne PersonnePorteuse
        {
            get { return this._personnePorteuse; }
            set 
            {
                if (value != null && this._personnePorteuse == null)
                {
                    this._personnePorteuse = value;
                }
                else if (value == null && this._personnePorteuse != null)
                {
                    this._personnePorteuse = value;
                }
            }
        }

        /// <summary>
        /// Ajouter une minute à l'heure de la montre.
        /// </summary>
        public void AjouterMinute()
        {
            this.Minute++;
            //Les cas de passage d'heure et de jour sont géré par les setters Minute et Heure.
            /*if(this.Minute > 59)
            {
                this.Minute = 0;
                this.Heure++;
                if(this.Heure > 23)
                {
                    this.Heure = 0;
                }
            }*/
        }

        /// <summary>
        /// Renvoie l'heure de la montre dans une chaine de caractères.
        /// </summary>
        /// <returns>L'heure sous forme de chaine de caractères.</returns>
        public string AfficherHeure()
        {
            return $"{this.Heure:D2}H{this.Minute:D2}";
        }
    }
}
