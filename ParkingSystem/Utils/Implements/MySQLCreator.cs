using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using ParkingSystem.Utils.Interfaces;
using MySql.Data.MySqlClient;

namespace ParkingSystem.Utils.Implements
{
    class MySQLCreator : DatabaseCreator, IDisposable
    {
        #region "Construtor"

        public MySQLCreator(string server, string user, string password):base(server, user, password, false)
        {
            this.conn = new MySqlConnection();
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
                string sql = "CREATE DATABASE IF NOT EXISTS PARKING";
                this.ExecuteSql(sql);

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

                if (versaoBanco < 1)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS USUARIOS(ID INT NOT NULL AUTO_INCREMENT, NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255) NOT NULL, SENHA VARCHAR(50) NOT NULL, PRIMARY KEY(ID))");
                    ExecuteSql("DELETE FROM USUARIOS WHERE ID = 1");
                    ExecuteSql("INSERT INTO USUARIOS(ID, NOME, EMAIL, SENHA) VALUES(1, 'ADMINISTRADOR', 'adm@darrieuxinfo.com', '')");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 2)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS CLIENTES(ID INT NOT NULL AUTO_INCREMENT, NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255), CPF VARCHAR(30) NOT NULL, LOGRADOURO VARCHAR(255), NUMERO VARCHAR(20), BAIRRO VARCHAR(255), CIDADE VARCHAR(255), UF VARCHAR(2), CEP VARCHAR(20), PRIMARY KEY(ID))");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 3)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS FABRICANTES(ID INT NOT NULL AUTO_INCREMENT, NOME VARCHAR(100) NOT NULL, PRIMARY KEY(ID))");
                    ExecuteSql("CREATE TABLE IF NOT EXISTS MODELOS(ID INT NOT NULL AUTO_INCREMENT, IDFABRICANTE INT NOT NULL, NOME VARCHAR(100) NOT NULL, MOTOR VARCHAR(100) NOT NULL, ANO INT NOT NULL, PRIMARY KEY(ID))");
                    ExecuteSql("CREATE TABLE IF NOT EXISTS VEICULOS(ID INT NOT NULL AUTO_INCREMENT, IDMODELO INT NOT NULL, IDCLIENTE INT NOT NULL, PLACA VARCHAR(10) NOT NULL, TIPO INT NOT NULL, PRIMARY KEY(ID))");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 4)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS ENDERECOS(ID INT NOT NULL AUTO_INCREMENT, LOGRADOURO VARCHAR(255), NUMERO VARCHAR(20), BAIRRO VARCHAR(255), CIDADE VARCHAR(255), UF VARCHAR(2), PRIMARY KEY(ID))");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 5)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS VAGAS(ID INT NOT NULL AUTO_INCREMENT, VAGA VARCHAR(100), PRIMARY KEY(ID))");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 6)
                {
                    ExecuteSql("CREATE TABLE IF NOT EXISTS ESTACIONAMENTO(ID INT NOT NULL AUTO_INCREMENT, IDVAGA INT NOT NULL, IDVEICULO INT NOT NULL, ENTRADA DATETIME NOT NULL, SAIDA DATETIME, VALORTOTAL DECIMAL, PRIMARY KEY (ID))");
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
            DbCommand cmd = new MySqlCommand();
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
            DbCommand cmd = new MySqlCommand();
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
                string sql = "CREATE TABLE IF NOT EXISTS CONFIGBANCO(ID INT NOT NULL AUTO_INCREMENT, VERSAO INT NOT NULL DEFAULT 0, PRIMARY KEY(ID))";
                this.ExecuteSql(sql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void CreateStringConnection()
        {
            strConn = $"Server={Server};Uid={User};Pwd={Password}";
        }

        #endregion
    }
}
