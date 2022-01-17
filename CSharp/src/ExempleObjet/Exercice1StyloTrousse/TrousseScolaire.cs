using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1StyloTrousse
{
    class TrousseScolaire : Trousse
    {
        private List<OutilEcriture> _affaires;

        public TrousseScolaire(int nombreOutilsMax) : base(nombreOutilsMax)
        {
            this._affaires = new List<OutilEcriture>();
        }

        public List<OutilEcriture> Affaires
        {
            get { return _affaires; }
        }

        public void RangerAffaire(OutilEcriture outilARanger)
        {
            if (this.EstOuverte)
            {
                if (!this.Affaires.Contains(outilARanger))
                {
                    if (this.Affaires.Count < this.NombreOutilsMax)
                    {
                        this.Affaires.Add(outilARanger);
                        Console.WriteLine($"{outilARanger.GetType()} ajouté.");
                    }
                    else
                    {
                        Console.WriteLine("Plus de place dans la trousse");
                    }
                }
                else
                {
                    Console.WriteLine("Cet outil est déjà rangé dans la trousse.");
                }

            }
            else
            {
                Console.WriteLine($"La trousse est fermée. Je ne peux pas y ranger ce {outilARanger.GetType()}.");
            }

        }

        public void SortirAffaire(OutilEcriture outilASortir)
        {
            if (this.EstOuverte)
            {
                if (this.Affaires.Contains(outilASortir))
                {
                    this.Affaires.Remove(outilASortir);
                    Console.WriteLine($"{outilASortir.GetType()} sorti.");
                }
                else
                {
                    Console.WriteLine("La trousse ne contient pas cet outil.");
                }
            }
            else
            {
                Console.WriteLine("La trousse est fermée. On ne peut rien en sortir.");
            }

        }

        public string GetAllAffaires()
        {
            StringBuilder result = new();
            foreach (OutilEcriture outil in this.Affaires)
            {
                result.Append(outil.GetType() + " avec une capacité de : " + outil.CapaciteEcriture +  "% de couleur : " + outil.Couleur + "\n");
            }

            return result.ToString();
        }
        
    }
}
