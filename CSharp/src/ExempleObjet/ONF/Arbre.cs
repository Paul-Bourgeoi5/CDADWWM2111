using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONF
{
    class Arbre
    {
        private readonly int hauteur;
        private readonly int diametre;
        private readonly TypeArbre typeArbre;
        private readonly Parcelle parcelle;

        public Arbre(
            TypeArbre typeArbre,
            int hauteur,
            int diametre,
            Parcelle parcelle)
        {
            this.typeArbre = typeArbre;
            this.hauteur = hauteur;
            this.diametre = diametre;
            this.parcelle = parcelle;
            parcelle.AjouterArbre(this);
        }
    }
}
