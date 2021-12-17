using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice_Recursif_2_10
    {
        public static void Run()
        {
            Console.WriteLine("Enter a sentence to check if it is a palindrome or not");
            string sentence = Console.ReadLine();

            Console.WriteLine(IsPalindrome(sentence));
        }

        private static bool IsPalindrome(string sentence)
        {
            if (sentence.Contains(' '))
            {
                sentence = sentence.Replace(" ", "").ToLower();
            }
            if (sentence.Length <= 1)
            {
                return true;
            }
            else
            {
                if (!sentence[0].Equals(sentence[^1]))
                {
                    return false;
                }
                else
                {
                    // return IsPalindrome(word.Substring(1, word.length -2));
                    return IsPalindrome(sentence[1..^1]);
                }
            }
        }
    }
}
