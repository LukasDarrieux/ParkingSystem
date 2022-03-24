using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Utils.Interfaces;
using ParkingSystem.Utils.Implements;


namespace ParkingSystem.Shared
{
    class Configuracoes
    {
        public static Database.Tipo SGBD { get; private set; }
        public static string Server { get; private set; }
        public static string User { get; private set; }
        public static string Password { get; private set; }

        public static void SetConfig(string sgbd, string server, string user, string password)
        {
            if (sgbd.ToUpper() == Database.Tipo.MySQL.ToString().ToUpper())
                SGBD = Database.Tipo.MySQL;
            else
                SGBD = Database.Tipo.SQLServer;

            Server = server;
            User = user;
            Password = password;
        }

        public static Database GetDatabase()
        {
            if (String.IsNullOrEmpty(Server) && String.IsNullOrEmpty(User) && String.IsNullOrEmpty(Password))
            {
                return null;
            }

            switch (SGBD)
            {
                case Database.Tipo.MySQL:
                    return new MySQL(Server, Database.NAME_DB, User, Password);

                case Database.Tipo.SQLServer:
                    return new SQLServer(Server, Database.NAME_DB);

                default:
                    return null;
            }
        }

    }
}
