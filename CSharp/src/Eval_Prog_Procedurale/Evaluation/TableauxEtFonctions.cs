using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    /// <summary>
    /// Répond aux besoins de l'exercice sur les tableaux statiques et fonctions
    /// </summary>
    class TableauxEtFonctions
    {
        private const int minArraySize = 1;
        private const int maxArraySize = 20;
        private const int minNumber = -50;
        private const int maxNumber = 50;

        /// <summary>
        /// Génère un tableau d'entiers de taille aléatoire entre 1 et 20 dont chaque élément a une valeur entre -50 et 50
        /// </summary>
        /// <returns>Un tableau statique d'entiers aléatoires</returns>
        public static int[] GenerateRandomIntArray()
        {
            int[] result;
            var randomIntGenerator = new Random();
            int arraySize = randomIntGenerator.Next(minArraySize, maxArraySize+1);
            result = new int[arraySize];

            for(var i = 0; i < arraySize; i++)
            {
                result[i] = randomIntGenerator.Next(minNumber, maxNumber+1);
            }

            return result;
        }

        /// <summary>
        /// Génère un tableau d'entiers généré selon les entrées de l'utilisateur (taille et valeurs)
        /// </summary>
        /// <returns>Un tableau d'entiers selon les entrées utilisateurs</returns>
        public static int[] GenerateUserIntArray()
        {
            int[] result;
            int arraySize;
            string[] userInputs;
            int userNumber;
            bool validNumber;
            do
            {
                Console.WriteLine("Entrer la taille de votre tableau (entre 1 et 20 max)");

            } while (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize < 1 || arraySize > 20 );
            result = new int[arraySize];

            // Entrée des valeurs dans le tableau de l'utilisateur
            do
            {
                validNumber = true;
                Console.WriteLine($"Entrer {arraySize} entiers séparés par un underscore '_' et dont la valeur est entre -50 et 50 max");

                userInputs = Console.ReadLine().Split('_');

                // Vérifier que les valeurs entrées sont bien des nombres et sont compris dans les valeurs limites 
                for (var i = 0; (i < userInputs.Length) && (i < result.Length); i++)
                {
                    validNumber = int.TryParse(userInputs[i], out userNumber);
                    if (validNumber && (userNumber < minNumber || userNumber > maxNumber))
                    {
                        validNumber = false;
                    }
                    if (validNumber)
                    {
                        result[i] = userNumber;
                    }

                }
            } while (!validNumber);

            return result;

        }

        /// <summary>
        /// Afficher les éléments d'un tableau d'entiers et sa taille
        /// </summary>
        /// <param name="intArray">Tableau d'entiers à afficher</param>
        public static void DisplayIntArray(int[] intArray)
        {
            Console.Write($"Les éléments du tableau sont : \"");
            foreach(int value in intArray)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine($"\" pour une taille totale de {intArray.Length} éléments.");
        }

        /// <summary>
        /// Affiche la moyenne, le minimum, le maximum et l'écart entre le minimum et le maximum d'un tableau d'entiers
        /// </summary>
        /// <param name="intArray">Tableau d'entiers que l'on veut observer</param>
        public static void DisplayCalculatedValuesFromIntArray(int[] intArray)
        {
            int sum = 0;
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            int minMaxDifference;

            for (var i = 0; i < intArray.Length; i++)
            {
                sum += intArray[i];
                if (intArray[i] < min)
                {
                    min = intArray[i];
                }
                if (intArray[i] > max)
                {
                    max = intArray[i];
                }
            }

            {
                minMaxDifference = max - min;
            }

            Console.WriteLine($"La moyenne est de {Math.Round((double)sum/(double)intArray.Length, 2)}\nLe minimum est {min}\nLe maximum est {max}\nL'écart entre le minimum et le maximum est de {minMaxDifference}");

        }

        public static void Run()
        {
            string userChoice;
            int[] intArray;
            Console.WriteLine("Voulez-vous entrer vous-même les valeurs d'un tableau statique ? ('OUI' pour le remplir, sinon il sera généré automatiquement)");
            userChoice = Console.ReadLine().ToUpper();

            if (userChoice == "OUI")
            {
                intArray = GenerateUserIntArray();
            }
            else
            {
                intArray = GenerateRandomIntArray();
            }

            DisplayIntArray(intArray);
            DisplayCalculatedValuesFromIntArray(intArray);
        }



    }
}
