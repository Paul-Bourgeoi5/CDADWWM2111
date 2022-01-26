using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SujetExamen
{
    class Question
    {
        private string _enonce;
        private int _difficulte;

        /// <summary>
        /// Constructeur de Question avec en paramètre son énoncé et sa difficulté.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        public Question(string e, int d)
        {
            this.Enonce = e;
            this.Difficulte = d;
        }

        /// <summary>
        /// Propriété de l'énonce de la question.
        /// </summary>
        public string Enonce { get { return _enonce; } init { _enonce = value; } }


        /// <summary>
        /// Propriété de la difficulté de la question.
        /// </summary>
        public int Difficulte { get { return _difficulte; } 
            set { 
                if (value < 0)
                {
                    _difficulte = 0;
                }
                else if(value > 100)
                {
                    _difficulte = 100;
                }
                else
                {
                    _difficulte = value;
                }
            }

        }

    }
}
