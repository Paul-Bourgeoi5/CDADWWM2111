using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONF
{
    class Parcelle
    {
        private readonly int id_parcelle;
        private readonly List<Arbre> arbres;
        private int surface;

        public Parcelle(int id)
        {
            this.id_parcelle = id;
            this.arbres = new List<Arbre>();
        }

        public void SetSurface(int surface)
        {
            this.surface = surface;
        }

        public int NombreArbre()
        {
            return this.arbres.Count;
        }

        public void AjouterArbre(Arbre arbre)
        {
            if (this.arbres.Contains(arbre))
            {
                throw new InvalidOperationException(
                    "L'arbre existe déjà dans cette parcelle");
            }

            this.arbres.Add(arbre);
        }
    }
}
