using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_8
    {
        public static void Run()
        {
            int year;
            Console.Write("Enter a year to check if it is a leap year : ");
            // Check if the user enter a number
            if (int.TryParse(Console.ReadLine(), out year))
            {

                // Use the Morgan's theorem : year % 4 == 0 && !(year % 100 == 0 && year % 400 != 0)
                if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                {
                    Console.WriteLine($"{year} is a leap year");
                }
                else
                {
                    Console.WriteLine($"{year} is not a leap year");
                }
            } 
            else
            {
                Console.WriteLine("INVALID FORMAT");
            }
        }
    }
}
