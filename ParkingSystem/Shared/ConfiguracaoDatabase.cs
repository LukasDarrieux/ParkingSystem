using ParkingSystem.Utils.Implements;
using System;

namespace ParkingSystem.Shared
{
    internal class ConfiguracaoDatabase
    {

        public static Database.Tipo SGBD { get; private set; }
        public static bool AutenticationWindows { get; private set; }
        public static string Server { get; private set; }
        public static string User { get; private set; }
        public static string Password { get; private set; }

        public static void SetConfig(string sgbd, string server, bool autenticationWindows, string user, string password)
        {
            if (sgbd.ToUpper() == Database.Tipo.MySQL.ToString().ToUpper())
                SGBD = Database.Tipo.MySQL;
            else
                SGBD = Database.Tipo.SQLServer;

            Server = server;
            AutenticationWindows = autenticationWindows;
            User = user;
            Password = password;
        }

        public static Database GetDatabase()
        {
            if (string.IsNullOrEmpty(Server) && string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Password))
            {
                return null;
            }

            switch (SGBD)
            {
                case Database.Tipo.MySQL:
                    return new MySQL(Server, Database.NAME_DB, User, Password);

                case Database.Tipo.SQLServer:
                    if (AutenticationWindows)
                        return new SQLServer(Server, Database.NAME_DB);
                    else
                        return new SQLServer(Server, Database.NAME_DB, User, Password);

                default:
                    return null;
            }
        }
    }
}
