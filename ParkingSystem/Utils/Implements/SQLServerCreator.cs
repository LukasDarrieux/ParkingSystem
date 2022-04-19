using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using ParkingSystem.Utils.Interfaces;

namespace ParkingSystem.Utils.Implements
{
    class SQLServerCreator : DatabaseCreator, IDisposable
    {
        #region "Construtor"

        public SQLServerCreator(string server, string user, string password) : base(server, user, password)
        {
            this.conn = new SqlConnection();
            this.CreateStringConnection();
        }

        #endregion

        #region "Métodos públicos"

        /// <summary>
        /// Cria o banco de dados caso ele não exista
        /// </summary>
        public override void CreateDatabase()
        {
            try
            {
                configConn();
                string sql = "CREATE DATABASE PARKING;";
                this.ExecuteSql(DatabaseExistsSQL(sql));

                conn.ChangeDatabase(NAME_DB);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Cria/Atualiza a estrutura do banco de dados
        /// </summary>
        public override void UpdateDatabase()
        {
            try
            {
                //Rotina para criar a tabela de config e de controle de versao do banco de dados
                CreateTableConfigDatabase();

                int versaoBanco = getVersaoBanco();

                string sql = string.Empty;

                if (versaoBanco < 1)
                {
                    sql = "CREATE TABLE USUARIOS(ID INT NOT NULL IDENTITY(1,1), NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255) NOT NULL, SENHA VARCHAR(50) NOT NULL, PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "USUARIOS"));
                    ExecuteSql("INSERT INTO USUARIOS(NOME, EMAIL, SENHA) VALUES('ADMINISTRADOR', 'adm@darrieuxinfo.com', '')");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 2)
                {
                    sql = "CREATE TABLE CLIENTES(ID INT NOT NULL IDENTITY(1,1), NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255), CPF VARCHAR(30) NOT NULL, LOGRADOURO VARCHAR(255), NUMERO VARCHAR(20), BAIRRO VARCHAR(255), CIDADE VARCHAR(255), UF VARCHAR(2), PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "CLIENTES"));
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 3)
                {
                    sql = "CREATE TABLE FABRICANTES(ID INT NOT NULL IDENTITY(1,1), NOME VARCHAR(100) NOT NULL, PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "FABRICANTES"));

                    sql = "CREATE TABLE MODELOS(ID INT NOT NULL IDENTITY(1,1), IDFABRICANTE INT NOT NULL, NOME VARCHAR(100) NOT NULL, MOTOR VARCHAR(100) NOT NULL, ANO INT NOT NULL, PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "MODELOS"));

                    sql = "CREATE TABLE VEICULOS(ID INT NOT NULL IDENTITY(1,1), IDMODELO INT NOT NULL, IDCLIENTE INT NOT NULL, PLACA VARCHAR(10) NOT NULL, TIPO INT NOT NULL, PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "VEICULOS"));
                    versaoBanco++;

                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            return;
        }

        #endregion

        #region "Métodos privados"

        private void ExecuteSql(string sql)
        {
            DbCommand cmd = new SqlCommand();
            try
            {
                if (!ConnIsOpen()) throw new ExceptionConnNotOpen();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
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

        private IDataReader ExecuteQuery(string sql)
        {
            DbDataReader reader;
            DbCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();
                return reader;
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

        private int getVersaoBanco()
        {
            DbDataReader reader = ExecuteQuery("SELECT * FROM CONFIGBANCO") as DbDataReader;
            try
            {
                if (!reader.HasRows)
                {
                    reader.Close();
                    ExecuteSql("INSERT INTO CONFIGBANCO (VERSAO) VALUES(0)");
                    return 0;
                }
                else
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32((int)CamposConfigBanco.VERSAO);
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

        }

        private void CreateTableConfigDatabase()
        {
            try
            {
                string sql = "CREATE TABLE CONFIGBANCO(ID INT NOT NULL IDENTITY(1,1), VERSAO INT NOT NULL DEFAULT 0, PRIMARY KEY(ID))";
                this.ExecuteSql(TableExistsSQL(sql, "CONFIGBANCO"));
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void CreateStringConnection()
        {
            strConn = $"Server={this.Server};Trusted_Connection=True;";
        }

        private string DatabaseExistsSQL(string sql)
        {
            return $"IF (NOT EXISTS (SELECT * FROM sys.databases WHERE Name = '{NAME_DB}')) " +
                $"BEGIN {sql} END";
        }

        private string TableExistsSQL(string sql, string tabela)
        {
            return $"IF(NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG='{NAME_DB}' AND TABLE_SCHEMA='dbo' AND TABLE_NAME='{tabela}'))" +
                $" BEGIN {sql} END ";
        }

        #endregion
    }
}
