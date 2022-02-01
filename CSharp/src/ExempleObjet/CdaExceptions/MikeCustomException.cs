using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaExceptions
{
    class MikeCustomException : Exception
    {
        public MikeCustomException(string message) : base(message)
        {
            
        }
    }
}
