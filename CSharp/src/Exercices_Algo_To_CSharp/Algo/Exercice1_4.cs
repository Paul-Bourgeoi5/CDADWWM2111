using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_4
    {
        public static void Run()
        {
            int a;
            int b;
            int temp;

            Console.Write("Enter an integer for a : ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter an integer for b : ");
            b = int.Parse(Console.ReadLine());

            temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"a is now {a} and b is {b}");
        }

    }
}
