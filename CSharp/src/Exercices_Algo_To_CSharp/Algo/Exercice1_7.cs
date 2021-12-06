using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_7
    {
        public static void Run()
        {
            int a;
            int b;
            int c;

            Console.WriteLine("Enter a, b and c which will be sorted");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());

            if (a < b)
            {
                if (c < a)
                {
                    Console.WriteLine($"{c}<{a}<{b}");
                }
                else
                {
                    if (c < b)
                    {
                        Console.WriteLine($"{a}<{c}<{b}");
                    }
                    else
                    {
                        Console.WriteLine($"{a}<{b}<{c}");
                    }
                }
            } else
            {
                if (a < c)
                {
                    Console.WriteLine($"{b}<{a}<{c}");
                }
                else
                {
                    if (b < c)
                    {
                        Console.WriteLine($"{b}<{c}<{a}");
                    } else
                    {
                        Console.WriteLine($"{c}<{b}<{a}");
                    }
                }
            }
        }
    }
}
