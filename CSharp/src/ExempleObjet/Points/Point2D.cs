using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Point2D
    {
        private int _x;
        private int _y;

        public int X
        {
            get 
            { 
                return _x; 
            }
            private init 
            {
                _x = value; 
            }
        }

        public int Y
        {
            get 
            { 
                return _y; 
            }
            private init 
            { 
                _y = value; 
            }
        }

        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return ($"Le point a les coordonnées ({X}, {Y})");
        }
    }
}
