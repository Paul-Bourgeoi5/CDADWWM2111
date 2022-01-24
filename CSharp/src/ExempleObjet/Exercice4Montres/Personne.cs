using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4Montres
{
    class Personne
    {
        private string _nom;
        private Montre _montrePortee;

        /// <summary>
        /// Constructeur d'une personne avec son nom en paramètre.
        /// </summary>
        /// <param name="nom"></param>
        public Personne(string nom)
        {
            this.Nom = nom;
            this._montrePortee = null;
        }

        public string Nom
        {
            get { return this._nom; }
            init { this._nom = value; }
        }

        public Montre MontrePortee
        {
            get { return this._montrePortee; }
            private set { this._montrePortee = value; }
        }


        /// <summary>
        /// Mettre la montre m à la personne si elle n'a pas déjà une montre.
        /// </summary>
        /// <param name="m"></param>
        public void MettreMontre(Montre m)
        {
            if (this.MontrePortee == null && m.PersonnePorteuse == null)
            {
                this.MontrePortee = m;
                m.PersonnePorteuse = this;
            }
        }

        /// <summary>
        /// Enlever la montre de la personne si elle en a une.
        /// </summary>
        public void EnleverSaMontre()
        {
            if (this.MontrePortee != null)
            {
                this.MontrePortee.PersonnePorteuse = null;
                this.MontrePortee = null;
            }
        }

        public string DemanderHeureA(Personne autrePersonne)
        {
            if (autrePersonne.MontrePortee != null)
            {
                return autrePersonne.MontrePortee.AfficherHeure();
            }
            else
            {
                return "Je n'ai pas de montre.";
            }
        }

    }
}
