using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Utils.Implements
{
    class ExceptionConnNotOpen : Exception
    {
        public ExceptionConnNotOpen() : base("Sem conexão com a base de dados")
        {
            
        }

    }
}
