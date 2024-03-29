﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using ParkingSystem.Models.Usuario;

namespace ParkingSystem.Utils.Implements
{
    class SQLServerCreator : DatabaseCreator, IDisposable
    {
        #region "Construtor"

        public SQLServerCreator(string server, string user, string password, bool autenticationWindows) : base(server, user, password, autenticationWindows)
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
                ConfigConn();
                string sql = "CREATE DATABASE PARKING;";
                ExecuteSql(DatabaseExistsSQL(sql));

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

                int versaoBanco = GetVersaoBanco();

                string sql = string.Empty;

                if (versaoBanco < 1)
                {
                    sql = "CREATE TABLE USUARIOS(ID INT NOT NULL IDENTITY(1,1), NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255) NOT NULL, SENHA VARCHAR(50) NOT NULL, PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "USUARIOS"));
                    ExecuteSql("INSERT INTO USUARIOS(NOME, EMAIL, SENHA) VALUES('ADMINISTRADOR', 'adm@darrieuxinfo.com', '12345678')");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 2)
                {
                    sql = "CREATE TABLE CLIENTES(ID INT NOT NULL IDENTITY(1,1), NOME VARCHAR(100) NOT NULL, EMAIL VARCHAR(255), CPF VARCHAR(30) NOT NULL, LOGRADOURO VARCHAR(255), NUMERO VARCHAR(20), BAIRRO VARCHAR(255), CIDADE VARCHAR(255), UF VARCHAR(2), CEP VARCHAR(20), PRIMARY KEY(ID))";
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

                if (versaoBanco < 4)
                {
                    sql = "CREATE TABLE ENDERECOS(ID INT NOT NULL IDENTITY(1, 1), LOGRADOURO VARCHAR(255), NUMERO VARCHAR(20), BAIRRO VARCHAR(255), CIDADE VARCHAR(255), UF VARCHAR(2), PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "ENDERECOS"));
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 5)
                {
                    sql = "CREATE TABLE VAGAS(ID INT NOT NULL IDENTITY(1, 1), VAGA VARCHAR(100), PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "VAGAS"));
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 6)
                {
                    sql = "CREATE TABLE ESTACIONAMENTO(ID INT NOT NULL IDENTITY(1, 1), IDVAGA INT NOT NULL, IDVEICULO INT NOT NULL, ENTRADA DATETIME NOT NULL, SAIDA DATETIME, VALORTOTAL DECIMAL(10, 2), PRIMARY KEY (ID))";
                    ExecuteSql(TableExistsSQL(sql, "ESTACIONAMENTO"));
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 7)
                {
                    sql = "CREATE TABLE CONFIGURACOES(ID INT NOT NULL IDENTITY(1, 1), TITULO VARCHAR(100), CARRO DECIMAL(10, 2) NOT NULL DEFAULT(0), MOTO DECIMAL(10, 2) NOT NULL DEFAULT(0), PERNOITE DECIMAL(10, 2) NOT NULL DEFAULT(0), PRIMARY KEY(ID))";
                    ExecuteSql(TableExistsSQL(sql, "CONFIGURACOES"));
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 8)
                {
                    ExecuteSql("INSERT INTO CONFIGURACOES(TITULO, CARRO, MOTO, PERNOITE) VALUES('', 0, 0, 0)");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 9)
                {
                    ExecuteSql("ALTER TABLE MODELOS ADD TIPO INT NOT NULL DEFAULT (1)");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 10)
                {
                    ExecuteSql("ALTER TABLE USUARIOS ADD TIPO INT NOT NULL DEFAULT(0)");
                    versaoBanco++;
                    ExecuteSql($"UPDATE CONFIGBANCO SET VERSAO = {versaoBanco}");
                }

                if (versaoBanco < 11)
                {
                    ExecuteSql($"UPDATE USUARIOS SET TIPO = {(int)Usuarios.TipoUsuario.ADMINISTRADOR} WHERE ID = 1");
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

        private int GetVersaoBanco()
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
            if (this.AutenticationWindows)
                strConn = $"Server={this.Server};Trusted_Connection=True;";
            else
                strConn = $"Server={this.Server}; User Id={this.User};Password={this.Password}; ";
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
