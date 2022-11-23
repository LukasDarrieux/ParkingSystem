using System;
using System.Data;
using System.Data.Common;

namespace ParkingSystem.Utils.Implements
{
    class DatabaseCreator : IDisposable
    {
        protected const string NAME_DB = Database.NAME_DB;

        protected enum CamposConfigBanco
        {
            ID = 0,
            VERSAO
        }

        protected DbConnection conn;

        protected static Database.Tipo Tipo { get; private set; }

        protected string strConn;
        protected string Server;
        protected string User;
        protected string Password;
        protected bool AutenticationWindows;

        protected DatabaseCreator(string server, string user, string password, bool autenticationWindows)
        {
            Server = server;
            User = user;
            Password = password;
            AutenticationWindows = autenticationWindows;
        }

        public virtual void CreateDatabase()
        {
            switch (Tipo)
            {
                case Database.Tipo.MySQL:
                    new MySQLCreator(Server, User, Password).CreateDatabase();
                    break;

                case Database.Tipo.SQLServer:
                    new SQLServerCreator(Server, User, Password, AutenticationWindows).CreateDatabase();
                    break;
            }
        }

        public virtual void UpdateDatabase()
        {
            switch (Tipo)
            {
                case Database.Tipo.MySQL:
                    new MySQLCreator(Server, User, Password).UpdateDatabase();
                    break;

                case Database.Tipo.SQLServer:
                    new SQLServerCreator(Server, User, Password, AutenticationWindows).UpdateDatabase();
                    break;
            }
         
        }

        public static DatabaseCreator GetDatabase(Database.Tipo tipo, string server, bool autenticationWindows, string user, string password)
        {
            Tipo = tipo;

            switch (tipo)
            {
                case Database.Tipo.MySQL:
                    return new MySQLCreator(server, user, password);
                    
                case Database.Tipo.SQLServer:
                    return new SQLServerCreator(server, user, password, autenticationWindows);

                default:
                    return null;
            }
        }

        protected virtual bool ConnIsOpen()
        {
            return conn.State == ConnectionState.Open;
        }

        protected virtual void OpenConn()
        {
            try
            {
                if (!ConnIsOpen())
                {
                    conn.Open();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        protected virtual void CloseConn()
        {
            try
            {
                if (ConnIsOpen())
                {
                    conn.Close();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        protected virtual void ConfigConn()
        {
            conn.ConnectionString = strConn;
            OpenConn();
        }

        public virtual void Dispose()
        {
            CloseConn();
            conn.Dispose();
            return;
        }
    }
}
