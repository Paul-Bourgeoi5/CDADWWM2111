﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    class Exercice1_1_1
    {
        public static void Run()
        {
            int nb1;
            int nb2;
            double result;

            Console.WriteLine("Enter a first number");
            nb1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second number");
            nb2 = Int32.Parse(Console.ReadLine());

            result = (nb1 + nb2) / 2d;

            Console.WriteLine("The average of the two numbers is " + result);
            Console.WriteLine($"The average of the two numbers is {result}");
        }
    }
}
