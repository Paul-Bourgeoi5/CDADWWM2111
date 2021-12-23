using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class TableauxStatiques
    {
        public static void Run()
        {
            string[] questions = {
                "Allez-vous bien ?",
                "Avez-vous votre permis de conduire ?",
                "Est-ce que tonton a encore 3g ?",
                "Est-ce que Bernie a sa pelle ?",
                "Est-ce que c'était dur ?",
                "Est-ce qu'on peut vous soudoyer ?"
            };
            string answer;

            string[] answers = new string[questions.Length];

            Console.WriteLine("<!> Veuillez répondre aux questions suivantes uniquement par vrai ou faux <!>");
            for (int i = 0; i < questions.Length; i++)
            {
                do
                {
                    Console.WriteLine(questions[i]);
                    answer = Console.ReadLine().ToLower();
                } while (((answer != "vrai") && (answer !="faux")));

                answers[i] = answer;
            }

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"A la question \"{questions[i]}\" vous avez répondu : \"{answers[i]}\"");
            }

        }
        
    }
}
