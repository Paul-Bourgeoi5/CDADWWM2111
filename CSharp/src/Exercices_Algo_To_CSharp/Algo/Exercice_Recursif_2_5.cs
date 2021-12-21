using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice_Recursif_2_5
    {
        public static int AdditionEntiersPositifs(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return AdditionEntiersPositifs(a, b - 1) + 1;
            }
        }

        public static int AdditionEntier(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else if (b < 0)
            {
                // b est négatif et doit aller vers 0 donc b+1
                return AdditionEntier(a, b + 1) - 1;
            }
            else
            {
                // b est posotif et doit aller vers 0 donc b-1
                return AdditionEntier(a, b - 1) + 1;
            }
        }
    }
}
