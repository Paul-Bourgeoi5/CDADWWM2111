using System;

namespace Algo
{
    static class Exercice1_1_2
    {
        public static void Run()
        {
            int nb1;
            int nb2;
            double result;
            bool redo;
            string answerForRedo;
            do
            {
                Console.WriteLine("Enter a first number for your average");
                nb1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a first second for your average");
                nb2 = int.Parse(Console.ReadLine());
                result = (nb1 + nb2) / 2D;
                Console.WriteLine($"The average of the two numbers is {result}");
                Console.WriteLine("The average of the two numbers is " + result);
                Console.WriteLine("\nDo you want to make another calculation? (Write 'Yes' to continue)");
                answerForRedo = Console.ReadLine().ToUpper();

                redo = answerForRedo.Equals("YES");
            } while (redo);
        }
    }
}
