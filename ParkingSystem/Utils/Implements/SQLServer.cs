using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ParkingSystem.Utils.Implements
{
    class SQLServer: Database, IDisposable
    { 
        
        #region "Atributos"

        public SqlConnection con = new SqlConnection();

        #endregion

        #region "Métodos públicos"

        /// <summary>
        /// Classe para conexão com o banco de dados SQL Server
        /// </summary>
        /// <param name="server">servidor</param>
        /// <param name="database">banco de dados</param>
        public SQLServer(string server, string database) : base(server, database)
        {
            string strConn = $"Server={this.Host};Database={this.DataBase};Trusted_Connection=True;";
            SettingConection(strConn);
        }

        public SQLServer(string server, string database, string user, string password) : base(server, database, user, password)
        {
            string strConn = $"Server={this.Host};Database={this.DataBase};User Id={this.User};Password={this.Password};";
            SettingConection(strConn);
        }



        /// <summary>
        /// Fecha a conexão com a base de dados
        /// </summary>
        public override void CloseConnection()
        {
            try
            {
                base.CloseConnection();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Executa consultas no banco de dados
        /// </summary>
        /// <param name="sqlQuery">consulta sql</param>
        /// <returns></returns>
        public override DbDataReader ExecuteQuery(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                _cmd = cmd;
                return base.ExecuteQuery(sqlQuery);
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Executa comandos no banco de dados
        /// </summary>
        /// <param name="sql">comando sql</param>
        public override void ExecuteSql(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                _cmd = cmd;
                base.ExecuteSql(sql);
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                cmd.Dispose();
            }

        }

        /// <summary>
        /// Verifica se a conexão está aberta
        /// </summary>
        /// <returns></returns>
        public override bool IsConnected()
        {
            return base.IsConnected();
        }

        /// <summary>
        /// Abre a conexão com o banco de dados
        /// </summary>
        public override void OpenConnection()
        {
            try
            {
                base.OpenConnection();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        public override void Dispose()
        {
            base.Dispose();
            if (!(con is null))
            {
                CloseConnection();
                con.Dispose();
            }
            
        }

        #endregion

        private void SettingConection(string stringConnection)
        {
            con.ConnectionString = stringConnection;
            _con = con;
            OpenConnection();
        }
    }
}