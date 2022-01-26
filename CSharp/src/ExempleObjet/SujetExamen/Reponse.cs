using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SujetExamen
{
    class Reponse
    {
        private string _enonce;
        private bool _valeurDeVerite;

        public Reponse(string e, bool verite)
        {
            this._enonce = e;
            this._valeurDeVerite = verite;
        }

        public string Enonce
        {
            get { return _enonce; }
        }

        public bool ValeurDeVerite
        {
            get { return _valeurDeVerite; }
        }
    }
}
