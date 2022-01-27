using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SujetExamen
{
    class QuestionAChoixMultiple : Question
    {
        private List<Reponse> _reponses;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">Enoncé</param>
        /// <param name="d">Difficulté</param>
        public QuestionAChoixMultiple(string e,int d) :base(e,d)
        {
            this._reponses = new List<Reponse>();
        }

        public List<Reponse> Reponses
        {
            get { return this._reponses; }
        }

        public void AjouterReponse(Reponse r)
        {
            this.Reponses.Add(r);
        }

        public void SupprimerReponse(Reponse r)
        {
            this.Reponses.Remove(r); 
        }

    }
}
