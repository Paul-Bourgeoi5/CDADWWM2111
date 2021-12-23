using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class Variables
    {
        static void Run()
        {
            const int year = 2000;
            const string nom = "Bob";
            const string prenom = "L'Éponge";
            const int age = 42;

            int saisie;
            Console.WriteLine($"Je suis {nom} {prenom} et j'ai {age} ans");
            Console.WriteLine("Vous avez quel age ?");
            saisie = Int32.Parse(Console.ReadLine());

            //Compare l'année actuelle - l'âge saisi avec l'année 2000
            if (DateTime.Now.Year - saisie > year)
            {
                Console.WriteLine("Vous êtes né après l'an 2000");
            }
            else
            {
                Console.WriteLine("Vous êtes né avant l'an 2000");
            }

        }

    }
}
