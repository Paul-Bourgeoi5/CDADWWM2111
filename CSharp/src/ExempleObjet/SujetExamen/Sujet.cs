using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SujetExamen
{
    class Sujet
    {
        private Dictionary<Question, int> _questions;

        public Sujet()
        {
            this._questions = new Dictionary<Question, int>();
        }

        public string AfficherSujetComplet()
        {
            string sujetComplet = "";
            int numeroQuestion = 1;
            
            foreach (KeyValuePair <Question,int> question in _questions)
            {
                Question questionEncours = question.Key;

                sujetComplet += numeroQuestion + ") " + questionEncours.Enonce + Environment.NewLine;

                if(questionEncours is QuestionAChoixMultiple maQuestion)
                {
                    foreach(Reponse reponseEnCours in maQuestion.Reponses)
                    {
                        sujetComplet += "\t" + reponseEnCours.Enonce + Environment.NewLine;
                    }

                    sujetComplet += Environment.NewLine;
                }

                numeroQuestion++;
            }

            return sujetComplet;
        }

        public Dictionary<Question, int> GetQuestions() 
        {
            return this._questions;
        }

        public void AjouterQuestion(Question q, int nombrePoints)
        {
            this._questions.Add(q,nombrePoints);
        }

        public void SupprimerQuestion(Question q)
        {
            this._questions.Remove(q);
        }

        public float CalculerDifficulteMoyenne()
        {
            if (this._questions.Count == 0)
                throw new ApplicationException(
                    "Vous devez avoir au moins une question");

            int totalDifficulteQuestions = 0;

            foreach(Question question in this._questions.Keys)
            {
                totalDifficulteQuestions += question.Difficulte;
            }

            return (float)totalDifficulteQuestions/(float)this._questions.Count;
        }

    }
}
