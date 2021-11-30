using System;
using System.Text;

namespace Algo
{
    class Exercice1_1_3
    {

        
        /// <summary>
        /// Split a string into an array of int
        /// </summary>
        /// <param name="_sentence">The string to be split</param>
        /// <param name="_charWhichSplit">The character which splits the string</param>
        /// <returns>An int[] containing every integer from a string</returns>
        private static int[] split(string _sentence, char _charWhichSplit)
        {
            int howManyInt;
            int numbersCounter;
            int[] arrayInt;
            // StringBuilder : une chaine de caractères dont on peut modifier le contenu
            StringBuilder numberInString;

            howManyInt = 1;
            for (int charCounter =0;  charCounter <= _sentence.Length - 1; charCounter++)
            {
                if (_sentence[charCounter].Equals(_charWhichSplit))
                {
                    howManyInt = howManyInt + 1;
                }
            }

            numbersCounter = 0;
            // avec string : numberInString = "";
            numberInString = new StringBuilder();
            arrayInt = new int[howManyInt];
            for (int charCounter = 0; charCounter < _sentence.Length; charCounter++)
            {
                if (!_sentence[charCounter].Equals(_charWhichSplit))
                {
                    // avec string : numberInString = numberInString + _sentence[charCounter];
                    numberInString.Append(_sentence[charCounter]);
                }
                if (_sentence[charCounter].Equals(_charWhichSplit) || 
                        charCounter == (_sentence.Length -1))
                {
                    // avec string : arrayInt[numbersCounter] = int.Parse(numberInString);
                    arrayInt[numbersCounter] = int.Parse(numberInString.ToString());
                    numbersCounter = numbersCounter + 1;
                    // avec string : numberInString = "";
                    numberInString.Clear();
                }
            }

            return arrayInt;
        }


        // static void Main(string[] args)   
        //remplacé par public static void Run() dans mon système de fichiers
        public static void Run()
        {
            string userInputNumbers;
            int howManyNumbers;
            int sumNumbers;
            int countNumbers;
            int[] arrayNumbers;
            double average;

            Console.WriteLine("enter some numbers spaced with ' '");
            userInputNumbers = Console.ReadLine();
            arrayNumbers = split(userInputNumbers, ' ');
            howManyNumbers = arrayNumbers.Length;
            sumNumbers = 0;

            for (countNumbers = 0; countNumbers < howManyNumbers ; countNumbers++)
            {
                sumNumbers = sumNumbers + arrayNumbers[countNumbers];
            }
            average = sumNumbers / howManyNumbers;
            Console.WriteLine($"Average of \"{userInputNumbers}\" is {average}");
        }
    }
}
