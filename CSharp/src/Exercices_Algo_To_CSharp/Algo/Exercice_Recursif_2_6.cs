using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice_Recursif_2_6
    {
        public static int ProduitEntiers(int a, int b)
        {
            if (b == 0)
            {
                return 0;
            }
            else
            {
                if (b < 0)
                {
                    return ProduitEntiers(a, b + 1) - a;
                }
                else
                {
                    return  ProduitEntiers(a, b - 1) + a;
                }

            }
        }
    }
}
