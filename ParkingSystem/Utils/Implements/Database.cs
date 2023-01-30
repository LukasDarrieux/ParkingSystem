using System;
using System.Data;
using System.Data.Common;
using ParkingSystem.Utils.Interfaces;

namespace ParkingSystem.Utils.Implements
{
    class Database : IDatabase, IDisposable
    {
        public const string NAME_DB = "PARKING";

        #region "Enumerador"
        public enum Tipo
        {
            MySQL,
            SQLServer,
        }

        #endregion

        #region "Atributos"

        protected string Host { get; set; }
        protected string DataBase { get; set; }
        protected string User { get; set; }
        protected string Password { get; set; }
        protected int Port { get; set; }
                       
        protected DbCommand _cmd;
        protected DbConnection _con;
        protected DbDataReader _dataReader;

        #endregion

        #region "Métodos públicos"
        public Database(string server, string database, string user, string password)
        {
            Host = server;
            DataBase = database;
            User = user;
            Password = password;
        }

        public Database(string server, string database)
        {
            Host = server;
            DataBase = database;
        }

        public virtual void OpenConnection()
        {
            try
            {
                if (!IsConnected()) _con.Open();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public virtual void CloseConnection()
        {
            try
            {
                if (IsConnected()) _con.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public virtual bool IsConnected()
        {
            return _con.State == ConnectionState.Open;
        }

        public virtual void ExecuteSql(string sql) 
        {
            try
            {
                if (!IsConnected()) throw new ExceptionConnNotOpen();
                _cmd.Connection = _con;
                _cmd.CommandText = sql;
                _cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public virtual DbDataReader ExecuteQuery(string sqlQuery)
        {
            try
            {
                if (!IsConnected()) throw new ExceptionConnNotOpen();
                _cmd.Connection = _con;
                _cmd.CommandText = sqlQuery;
                _dataReader = _cmd.ExecuteReader();
                return _dataReader;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public virtual void Dispose()
        {
            if (!(_cmd is null)) _cmd.Dispose();

            if (!(_dataReader is null))
            {
                _dataReader.Close();
                _dataReader.Dispose();
            }

            if (!(_con is null))
            {
                CloseConnection();
                _con.Dispose();
            }
                
        }

        #endregion

    }
}
