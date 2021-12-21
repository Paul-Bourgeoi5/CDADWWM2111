using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice_Recursif_2_7
    {
        public static double PuissanceEntiers(double a, double b)
        {
            if (b == 0)
            {
                return 1;
            }
            else
            {
                if (b < 0)
                {
                    return PuissanceEntiers(a, b + 1) / a;
                }
                else
                {
                    return PuissanceEntiers(a, b - 1) * a;
                }

            }
        }
    }
}
