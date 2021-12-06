using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_9
    {
        public static void Run()
        {
            int number;

            Console.Write("Enter a number to find its divisors : ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                for (int i = 2; i <= number/2; i++)
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine($"{i} is a divisor of {number}");
                    }
                }
            }
        }
    }
}
