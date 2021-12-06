using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice1_2
    {
        public static void Run()
        {
            double radius;
            double area;
            double volume;

            Console.WriteLine("Enter a radius to calculate the area and volume of the sphere");
            radius = double.Parse(Console.ReadLine());
            area = 4 * Math.PI * Math.Pow(radius, 2);
            volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
            Console.WriteLine($"With a radius of {radius}, the sphere has an" +
                $"area of {area} and a volume of {volume}");

        }
    }
}
