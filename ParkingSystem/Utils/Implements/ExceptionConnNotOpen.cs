using System;

namespace ParkingSystem.Utils.Implements
{
    class ExceptionConnNotOpen : Exception
    {
        public ExceptionConnNotOpen() : base("Sem conexão com a base de dados")
        {
            
        }

    }
}
