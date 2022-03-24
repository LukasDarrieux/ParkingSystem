using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using ParkingSystem.Utils.Interfaces;

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

        protected DatabaseCreator(string server, string user, string password)
        {
            this.Server = server;
            this.User = user;
            this.Password = password;
        }

        public virtual void CreateDatabase()
        {
            switch (Tipo)
            {
                case Database.Tipo.MySQL:
                    new MySQLCreator(Server, User, Password).CreateDatabase();
                    break;

                case Database.Tipo.SQLServer:
                    new SQLServerCreator(Server, User, Password).CreateDatabase();
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
                    new SQLServerCreator(Server, User, Password).UpdateDatabase();
                    break;
            }
         
        }

        public static DatabaseCreator GetDatabase(Database.Tipo tipo, string server, string user, string password)
        {
            Tipo = tipo;

            switch (tipo)
            {
                case Database.Tipo.MySQL:
                    return new MySQLCreator(server, user, password);
                    
                case Database.Tipo.SQLServer:
                    return new SQLServerCreator(server, user, password);

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

        protected virtual void configConn()
        {
            conn.ConnectionString = this.strConn;
            OpenConn();
        }

        public virtual void Dispose()
        {
            this.CloseConn();
            conn.Dispose();
            return;
        }
    }
}
