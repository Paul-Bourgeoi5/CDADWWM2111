using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie
{
    class Segment2D
    {
        private Point2D _p1;

        public Point2D P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }

        private Point2D _p2;

        public Point2D P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }


        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Segment2D()
        {
            P1 = new Point2D(0, 0);
            P2 = new Point2D(1,1);
        }

        /// <summary>
        /// Constructeur avec les 2 points aux extrémités en paramètres.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Segment2D(Point2D p1, Point2D p2)
        {
            P1 = p1;
            P2 = p2;
        }

        /// <summary>
        /// Constructeur avec coordonnées des 2 points aux extrémités en paramètres.
        /// </summary>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        public Segment2D(int p1X, int p1Y, int p2X, int p2Y)
        {
            P1 = new Point2D(p1X, p1Y);
            P2 = new Point2D(p2X, p2Y);
        }

        /// <summary>
        /// Deplacement d'un segment en plaçant P1 sur les coordonnées en paramètres.
        /// </summary>
        /// <param name="x">Nouvelle coordonnées de P1 en x.</param>
        /// <param name="y">Nouvelle coordonnées de P1 en y.</param>
        public void DeplacerVersPosition(int x, int y)
        {
            int deplacementX = CalculDuDeplacement(P1.X, x);
            int deplacementY = CalculDuDeplacement(P1.Y, y);

            P1.DeplacerVersPosition(x, y);

            P2.DeplacerDe(deplacementX, deplacementY);
        }

        /// <summary>
        /// Calcule l'écart entre 2 coordonnées sur le même axe.
        /// </summary>
        /// <param name="origine">coordonnée d'origine</param>
        /// <param name="destination">coordonnée d'arrivée</param>
        /// <returns></returns>
        private int CalculDuDeplacement(int origine, int destination)
        {
            return destination - origine;
        }

        /// <summary>
        /// Déplacement du segment de nombreADeplacerX sur l'axe x et de nombreADeplacerY sur l'axe y.
        /// </summary>
        /// <param name="nombreADeplacerX">Deplacement du segment de X sur l'axe x.</param>
        /// <param name="nombreADeplacerY">Deplacement du segment de Y sur l'axe y.</param>
        public void DeplacerDe(int nombreADeplacerX, int nombreADeplacerY)
        {
            P1.DeplacerDe(nombreADeplacerX, nombreADeplacerY);
            P2.DeplacerDe(nombreADeplacerX, nombreADeplacerY);
        }


        public override string ToString()
        {
            return ($"[P1{P1} ; P2{P2}]");
        }

        /// <summary>
        /// Finalizer (Ce qui se passe à la destruction de l'objet par le garbage collector)
        /// </summary>
        ~Segment2D()
        {
            Console.WriteLine("RIP Segment2D");
        }
    }
}
