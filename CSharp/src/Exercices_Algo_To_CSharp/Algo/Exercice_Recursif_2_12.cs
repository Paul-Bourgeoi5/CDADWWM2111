using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice_Recursif_2_12
    {
        
        public static void Run()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            int n;
            string word;
            char[] temp;
            string sortedWord;
            bool validNumber;
            Console.WriteLine("Entrez une chaine de caractères (différents les uns les autres)");
             word = Console.ReadLine();
            temp = word.ToCharArray();
            Array.Sort(temp);
            sortedWord = new string(temp);
            do
            {
                Console.WriteLine("Entrez le numéro de permutation que vous voulez");
                validNumber = int.TryParse(Console.ReadLine(), out n);
                if (validNumber)
                {
                    validNumber = (n >= 0 && n < Facto(sortedWord));
                }
            } while (!validNumber);

            GetNthPermutation(sortedWord, ref n);


        }

        public static int Facto(string sortedWord)
        {
            int length = sortedWord.Length;
            int result = 1;
            if (length < 2)
                return result;
            for (int i = 2; i <= length; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="numberOfPermutationsRemaining"></param>
        /// <author>FTurleque</author>
        /// <returns></returns>
        public static void GetNthPermutation(string word,ref int numberOfPermutationsRemaining, string prefix = "")
        {
            if (word.Length == 0)
            {
                if (numberOfPermutationsRemaining == 0)
                {
                    Console.WriteLine(prefix);
                }
                numberOfPermutationsRemaining--;
            }
            for (int i = 0; i < word.Length; i++)
            {
                GetNthPermutation(TakeOffIthCharOfWord(word, i), ref numberOfPermutationsRemaining,
                    AddACharacterOfAWordToTheWordsPrefix(prefix, word, i));
                
            }
        }

        /// <summary>
        /// Renvoie un mot après lui avoir le caractère numéro charNumber
        /// </summary>
        /// <param name="word"></param>
        /// <param name="iThChar"></param>
        /// <returns>Un mot avec le caractère charNumber en moins</returns>
        private static string TakeOffIthCharOfWord(string word, int iThChar)
        {
            //      Prendre le début du mot avant le caractère charNumber + ajoute le reste du mot après le caractère charNumber
            return( word.Substring(0, iThChar) + word.Substring(iThChar + 1, word.Length - (iThChar + 1)));
        }


        /// <summary>
        /// Take the numberChar th character in word and add it to the prefix
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="word"></param>
        /// <param name="charNumber"></param>
        /// <returns>The prefix with a character taken from the word</returns>
        private static string AddACharacterOfAWordToTheWordsPrefix(string prefix, string word, int charNumber)
        {
            return (prefix + word[charNumber]);
        }
    }
}
