using System;

namespace Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Point2D p1 = new Point2D(3, 2);
            Point2D p2 = new Point2D(4, 4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);


            Point3D p3 = new Point3D(1, 0, 1);
            Console.WriteLine(p3);
        }
    }
}
