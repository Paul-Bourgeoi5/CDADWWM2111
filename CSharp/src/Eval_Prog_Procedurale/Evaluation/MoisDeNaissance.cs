using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class MoisDeNaissance
    {
        public static void Run()
        {
            string[] months = { "janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre", "novembre", "décembre" };
            int userIntMonth;
            bool validNumber;
            Console.Write("Entrer le numéro de votre mois de naissance : ");
            validNumber = Int32.TryParse(Console.ReadLine(), out userIntMonth);
             while (!validNumber || userIntMonth < 1 || userIntMonth > 12)
            {
                Console.WriteLine("Entrer un nombre entre 1 et 12 inclus qui correspond à votre mois de naissance");
                validNumber = Int32.TryParse(Console.ReadLine(), out userIntMonth);
            }

            Console.WriteLine($"{userIntMonth} correspond au mois de {months[userIntMonth - 1]}");
        }

    }
}
