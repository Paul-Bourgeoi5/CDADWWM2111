using Geometrie;
using System;

namespace Geometrie
{
    class Program
    {
        static void Main(string[] args)
        {

            Point2D p1 = new Point2D(3, 2);
            Point2D p2 = new Point2D(4, 4);
            Segment2D segment1 = new Segment2D(p1, p2);
            Segment2D segment2 = new Segment2D(2, 2, -6, -4);
            /*Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());*/

            Console.WriteLine("Segment 1 : " + segment1.ToString());
            Console.WriteLine("Segment 2 : " + segment2.ToString());
            segment2.DeplacerVersPosition(0, 0);

            Console.WriteLine("Segment 2 : " + segment2.ToString());

            segment2.DeplacerDe(4, 4);
            Console.WriteLine("Segment 2 : " + segment2.ToString());

            /*Point3D p3 = new Point3D(1, 0, 1);
            Console.WriteLine(p3.ToString());*/


        }

    }
}
