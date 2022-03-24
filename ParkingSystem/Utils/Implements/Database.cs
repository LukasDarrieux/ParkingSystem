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

        protected string _host { get; set; }
        protected string _database { get; set; }
        protected string _user { get; set; }
        protected string _password { get; set; }
        protected int _port { get; set; }
                       
        protected DbCommand _cmd;
        protected DbConnection _con;
        protected DbDataReader _dataReader;

        #endregion

        #region "Métodos públicos"
        public Database(string server, string database, string user, string password)
        {
            this._host = server;
            this._database = database;
            this._user = user;
            this._password = password;
        }

        public Database(string server, string database)
        {
            this._host = server;
            this._database = database;
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
                if (!this.IsConnected()) throw new ExceptionConnNotOpen();
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
                if (!this.IsConnected()) throw new ExceptionConnNotOpen();
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
            if (!(this._cmd is null)) this._cmd.Dispose();

            if (!(this._dataReader is null))
            {
                this._dataReader.Close();
                this._dataReader.Dispose();
            }

            if (!(this._con is null))
            {
                this.CloseConnection();
                this._con.Dispose();
            }
                
        }

        #endregion

    }
}
