using System;

namespace Exercice3PoupeeRusse
{

    class PoupeeRusse
    {
        // Taille de la poupée.
        private int _taille;
        // True si la poupée est ouverte. False si elle est fermée.
        private bool _estOuverte;
        // Poupée russe dans laquelle se trouve la poupée courante.
        private PoupeeRusse _dans;
        // Poupée russe contenue à l'intérieur de la poupée courante.
        private PoupeeRusse _contenue;

        /// <summary>
        /// Constructeur d'une poupée russe.
        /// </summary>
        /// <param name="taille">Taille de la poupée à construire.</param>
        public PoupeeRusse(int taille)
        {
            this._taille = taille;
            this._estOuverte = false;
            this._dans = null;
            this._contenue = null;
        }

        /// <summary>
        /// Propriété pour accéder à la _taille d'une poupée russe. (getter et init)
        /// </summary>
        public int Taille
        {
            get { return this._taille; } 
            init { this._taille = value; }
        }

        /// <summary>
        /// Propriété pour accéder à _estOuverte d'une poupée russe. (getter et private setter)
        /// </summary>
        public bool EstOuverte
        {
            get { return this._estOuverte; }
            private set { this._estOuverte = value; }
        }

        /// <summary>
        /// Propriété pour accéder à la poupée russe _dans laquelle est la poupée actuelle. (getter et setter)
        /// </summary>
        public PoupeeRusse Dans
        {
            get { return this._dans; }
            set { this._dans = value; }
        }

        /// <summary>
        /// Propriété pour accéder à la poupée russe _contenue dans la poupée actuelle. (getter et setter)
        /// </summary>
        public PoupeeRusse Contenue
        {
            get { return this._contenue; }
            set { this._contenue = value; }
        }

        /// <summary>
        /// Ouvre la poupée si elle n'est pas ouverte et si elle ne se trouve pas dans une autre poupée.
        /// </summary>
        public void Ouvrir()
        {
            // this.Dans == null test si la poupée est dans aucun autre poupée
            if (!this.EstOuverte && this.Dans == null)
            {
                this.EstOuverte = true;
                Console.WriteLine($"Ouverture de la poupée de taille {this.Taille}.");
            }
            else
            {
                Console.WriteLine("♥/!\\/!\\/!\\♥ Ouverture impossible. ♥/!\\/!\\/!\\♥");
            }
        }

        /// <summary>
        /// Ferme la poupée si elle n'est pas déjà fermée et si elle ne se trouve pas à l'intérieur d'une autre poupée.
        /// </summary>
        public void Fermer()
        {
            // this.Dans == null test si la poupée est dans aucun autre poupée
            if (this.EstOuverte && this.Dans == null)
            {
                this.EstOuverte = false;

                Console.WriteLine($"Fermeture de la poupée de taille {this.Taille}.");
            }
            else
            {
                Console.WriteLine("♥/!\\/!\\/!\\♥ Fermeture impossible. ♥/!\\/!\\/!\\♥");
            }
        }

        /// <summary>
        /// Place la poupée courante dans la poupée p si possible.
        /// </summary>
        /// <param name="p">Poupée dans laquelle placer la poupée actuelle.</param>
        public void PlacerDans(PoupeeRusse p)
        {
            // rappel : !this.EstOuverte est équivalent à this.EstOuverte == false
            // Si poupée actuelle fermée et dans aucune autre poupée et si poupée p est ouverte et ne contient pas d'autre poupée et de taille supérieure à poupée actuelle.
            if (!this.EstOuverte && this.Dans == null && p.EstOuverte && p.Contenue == null && p.Taille > this.Taille)
            {
                this.Dans = p;
                p.Contenue = this;
                Console.WriteLine($"Je met une poupée de taille {this.Taille} dans une poupée de taille {p.Taille}");
            }
            else
            {
                Console.WriteLine($"♥/!\\/!\\/!\\♥ Impossible de mettre la poupée de taille {this.Taille} dans une poupée de taille {p.Taille} ♥/!\\/!\\/!\\♥");
            }
        }

        /// <summary>
        /// Sortir la poupée courante de la poupée p si elle est dans p et si p est ouverte.
        /// </summary>
        /// <param name="p">Poupée de laquelle on essaie de sortir la poupée courante</param>
        public void SortirDe(PoupeeRusse p)
        {
            if (this.Dans == p && p.EstOuverte)
            {
                this.Dans = null;
                p.Contenue = null;
                Console.WriteLine($"Je sort une poupée de taille {this.Taille} de la poupée de taille {p.Taille}");
            }
            else
            {
                Console.WriteLine($"♥/!\\/!\\/!\\♥ Impossible de sortir la poupée de taille {this.Taille} de la poupée de taille {p.Taille} ♥/!\\/!\\/!\\♥");
            }
        }

        // Pour Ernest
        /// <summary>
        /// Compte le nombre de poupées emboitées les unes dans les autres à partir d'une poupée.
        /// </summary>
        /// <param name="poupee">La poupée à partir de laquelle on veut commencer à compter.</param>
        /// <returns>Le nombre de poupées emboitées les une dans les autres avec une valeur minimale de 1 dans le cas d'une poupées sans autre poupée à l'intérieur</returns>
        public static int CompterLesPoupeesEmboitees(PoupeeRusse poupee)
        {
            if (poupee.Contenue == null)
            {
                return 1;
            }
            else
            {
                return 1 + CompterLesPoupeesEmboitees(poupee.Contenue);
            }
        }
    }
}
