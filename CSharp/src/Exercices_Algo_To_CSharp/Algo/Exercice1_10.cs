using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_10
    {
        public static void Run()
        {
            long n;
            int number;
            int sumOfDivisors;

            do
            {
                Console.Write("Enter a number of perfect numbers to find or something else to quit : ");

                if (long.TryParse(Console.ReadLine(), out n))
                {
                    number = 2;
                    do
                    {
                        sumOfDivisors = 0;
                        for (int i = 1; i <= number / 2; i++)
                        {
                            if (number % i == 0)
                            {
                                sumOfDivisors += i;
                            }
                        }
                        if (number == sumOfDivisors)
                        {
                            Console.WriteLine($"Then {number} is a perfect number");
                            n--;
                        }
                        number++;
                    } while (n > 0);
                }
                else
                {
                    Console.WriteLine("Bye bye");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } while (true);
        }
    }
}
