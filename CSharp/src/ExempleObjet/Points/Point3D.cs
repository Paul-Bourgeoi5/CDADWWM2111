using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie
{
    /// <summary>
    /// Classe qui représente un point dans un espace à 3 dimensions.
    /// </summary>
    class Point3D : Point2D
    {
        private int _z;

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Point3D() : base()
        {
            Z = 0;
        }

        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})"; ;
        }
    }
}
