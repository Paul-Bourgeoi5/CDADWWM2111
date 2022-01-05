using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie
{
    /// <summary>
    /// Classe qui représente un point dans un espace à 2 dimensions.
    /// </summary>
    class Point2D
    {
        // Attributs d'un Point2D : _x et _y, valeurs respectives en abscisse et ordonnée.
        private int _x;
        private int _y;

        /// <summary>
        /// Propriété d'accès à l'attribut _x.
        /// </summary>
        public int X
        {
            get 
            { 
                return _x; 
            }
            set 
            {
                _x = value; 
            }
        }

        /// <summary>
        /// Propriété d'accès à l'attribut _y.
        /// </summary>
        public int Y
        {
            get 
            { 
                return _y; 
            }
            set 
            { 
                _y = value; 
            }
        }

        /// <summary>
        /// Constructeur par défaut d'un Point2D avec coordonnées (0, 0).
        /// </summary>
        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Constructeur avec en paramètres l'abscisse et l'ordonnée d'un Point2D.
        /// </summary>
        /// <param name="x">Valeur en abscisse.</param>
        /// <param name="y">Valeur en ordonnée.</param>
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Surcharge de la méthode ToString() pour afficher les valeurs d'un Point2D.
        /// </summary>
        /// <returns>Les coordonnées du point 2D.</returns>
        public override string ToString()
        {
            return ($"({X}, {Y})");
        }

        public void DeplacerVersPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DeplacerDe(int nombreADeplacerX, int nombreADeplacerY)
        {
            X = X + nombreADeplacerX;
            Y = Y + nombreADeplacerY;
        }

    }
}
