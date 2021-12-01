using System;
using System.Text;
using System.Collections.Generic;

namespace Algo
{
    class Exercice1_1_3
    {
        /// <summary>
        /// Split a string _sentence depending on specified char into a static array of integers
        /// </summary>
        /// <param name="_sentence"></param>
        /// <param name="_charWhoSplit"></param>
        /// <returns>Returns _sentence split depending on _charWhoSplit</returns>
        private static int[] Split(string _sentence, char _charWhoSplit)
        {
            int howManyInt;
            int numbersCounter;
            int charCounter;
            int[] listInt;
            StringBuilder numberInString;

            howManyInt = 0;
            for(charCounter = 0 ; charCounter <= _sentence.Length -1 ; charCounter++)
            {
                if (_sentence[charCounter] == _charWhoSplit)
                {
                    //howManyInt = howManyInt + 1;
                    howManyInt++;
                }
            }
            howManyInt++;
            numbersCounter = 0;
            numberInString = new StringBuilder();
            // déclare la taille du tableau listInt et l'instancie
            listInt = new int[howManyInt];

            for (charCounter = 0; charCounter <= _sentence.Length - 1; charCounter++)
            {
                if (_sentence[charCounter] != _charWhoSplit)
                {
                    // pourrait être : numberInString += _sentence[charCounter];
                    numberInString.Append(_sentence[charCounter]);
                }
                if (_sentence[charCounter] == _charWhoSplit || charCounter == (_sentence.Length - 1))
                {
                    listInt[numbersCounter] = int.Parse(numberInString.ToString());
                    numbersCounter++;
                    numberInString.Clear();
                }
            }
            return listInt;
        }  

        public static void Run()
        {
            string userInputNumbers;
            int howManyNumbers;
            int sumNumbers;
            int countNumbers;
            int[] listNumbers;
            //string[] listString;
            double average;

            Console.WriteLine("Enter numbers");
            userInputNumbers = Console.ReadLine();
            listNumbers = Split(userInputNumbers, ' ');

            /* Sans utiliser notre propre split :
             * listString = userInputNumbers.Split(' ');
            listNumbers = new int[listString.Length];
            for(int i = 0; i < listString.Length; i++)
            {
                listNumbers[i] = int.Parse(listString[i]);
            }*/

            howManyNumbers = listNumbers.Length;
            sumNumbers = 0;

            for (countNumbers = 0; countNumbers <= howManyNumbers - 1; countNumbers++)
            {
                sumNumbers += listNumbers[countNumbers];
            }
            average = (double)sumNumbers / (double)howManyNumbers;
            Console.WriteLine($"\nAverage of \"{userInputNumbers}\" is {average}");
        }
        

        public static void JuniorRun()
        {
            string[] numbers;
            string saisie;
            double average = 0d;

            Console.WriteLine("Saisissez des nombres séparés par un espace");
            saisie = Console.ReadLine();
            numbers = saisie.Split(' ');
            for(int i = 0; i < numbers.Length; i++)
            {
                average += double.Parse(numbers[i]);
            }

            Console.WriteLine($"La moyenne de vos nombres est {average/(double)numbers.Length}");
        }
        
    }
}
