using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ParkingSystem.Utils.Interfaces;

namespace ParkingSystem.Utils.Implements
{
    class MySQL : Database, IDisposable
    {
        #region "Atributos"

        public MySqlConnection con = new MySqlConnection();
        
        #endregion

        #region "Métodos públicos"

        /// <summary>
        /// Classe para conexão com o banco de dados MySQL
        /// </summary>
        /// <param name="server">servidor</param>
        /// <param name="database">banco de dados</param>
        /// <param name="user">usuário</param>
        /// <param name="password">senha</param>
        public MySQL(string server, string database, string user, string password) : base(server, database, user, password)
        {
            string strConn = $"Server={this._host};Database={this._database};Uid={this._user};Pwd={this._password};";
            con.ConnectionString = strConn;
            base._con = con;
            this.OpenConnection();
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
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                base._cmd = cmd;
                MySqlDataReader reader = (MySqlDataReader) base.ExecuteQuery(sqlQuery);
                return reader;
            }
            catch(Exception error)
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
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                base._cmd = cmd;
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
            if (!(this.con is null))
            {
                this.CloseConnection();
                this.con.Dispose();
            }
        }
        
        #endregion
    }
}
