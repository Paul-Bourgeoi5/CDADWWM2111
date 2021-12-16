using System;

namespace Algo
{
    /// <summary>
    /// Jeu du pendu
    /// </summary>
    class Exercice3_6
    {
        public static void Run()
        {
            string wordToFind;

            char[] foundLetters;

            char suggestedLetter;

            const int maxAttempts = 6;

            const int minWordLength = 5;

            int attemptsCounter = 0; 
            int    i;

            bool noVictory = true; 
            bool noMistake;

            do
            {
                Console.WriteLine($"Enter a word with {minWordLength} or more characters");
                wordToFind = Console.ReadLine();

            } while (wordToFind.Length < minWordLength);
            Console.Clear();

            foundLetters = FirstAndLastLetterOfWord(wordToFind);

            Console.WriteLine($"{new string(foundLetters)}");

            do
            {
                noMistake = false;
                Console.WriteLine("Enter a letter, please ");
                suggestedLetter = Console.ReadLine()[0];

                for (i = 0; i < wordToFind.Length; i++)
                {
                    if (suggestedLetter == wordToFind[i])
                    {
                        foundLetters[i] = suggestedLetter;
                        noMistake = true;
                    }
                }

                if (!noMistake)
                {
                    attemptsCounter = attemptsCounter + 1;
                }
                if (new string(foundLetters).Equals(wordToFind))
                {
                    noVictory = false;
                    Console.WriteLine("you win. the word was: " + wordToFind);
                }
                else
                {
                    Console.WriteLine($"{new string(foundLetters)} Attempts : {maxAttempts - attemptsCounter}");

                }


            } while (attemptsCounter < maxAttempts && noVictory);
            if (attemptsCounter >= maxAttempts)
            {
                Console.WriteLine("failled");
            }




        }

        private static char[] FirstAndLastLetterOfWord(string word)
        {
            char[] result;
            const char dash = '-';
            int i;

            result = new char[word.Length];
            result[0] = word[0];
            result[word.Length - 1] = word[word.Length - 1];
            for ( i = 1; i < word.Length-1; i++)
            {
                result[i] = dash;
            }
            return result;


        }
    }
}
