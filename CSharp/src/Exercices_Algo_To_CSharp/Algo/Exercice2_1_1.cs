using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    class Exercice2_1_1
    {
        public static void Run()
        {
            const double min = 0.01;
            const double max = 1000000;
            string userInput;
            double number;
            bool isNumber;
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Please enter a valid value between 0.01 and 1.000.000 or quit with 'q'");
                userInput = Console.ReadLine();
                isNumber = double.TryParse(userInput, out number);
                if (isNumber && number > min && number < max)
                {
                    Console.WriteLine($"{number} kilometers is equal to {number / 1.609d} miles\n");
                }
                else
                {
                    if (userInput.Equals("q"))
                    {
                        keepGoing = false;
                        Console.WriteLine("\nBye bye");
                    }
                    else
                    {
                        Console.WriteLine("\nINVALID VALUE\n");
                    }
                }
            }
        }
    }
}
