using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Point3D : Point2D
    {
        private int _z;

        public int Z
        {
            get { return _z; }
            init { _z = value; }
        }

        public Point3D() : base()
        {
            Z = 0;
        }

        public Point3D(int x, int y, int z):base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return ($"Le point a les coordonnées ({X}, {Y}, {Z})"); ;
        }
    }
}
