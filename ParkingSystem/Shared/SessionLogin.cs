using ParkingSystem.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Shared
{
    class SessionLogin
    {
        private static Usuarios Usuario;

        public static void SetUsuarioSession(Usuarios usuario)
        {
            Usuario = usuario;
        }

        public static Usuarios GetUsuarioSession()
        {
            return Usuario;
        }
    }
}
