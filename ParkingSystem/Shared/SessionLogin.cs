using ParkingSystem.Models.Usuario;

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
