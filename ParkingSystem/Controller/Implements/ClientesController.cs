using System;
using System.Collections.Generic;
using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Utils.Interfaces;
using ParkingSystem.Shared;
using ParkingSystem.Models.Pessoa;
using System.Data.Common;

namespace ParkingSystem.Controller.Implements
{
    class ClientesController : IClientesController, ICrud, IDisposable
    {

        #region "Atributos"

        private readonly Clientes _cliente;
        private readonly IDatabase db;
        private const string TABELA = "CLIENTES";

        #endregion

        #region "Construtores"

        public ClientesController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        public ClientesController(Clientes cliente)
        {
            this._cliente = cliente;
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public bool Delete()
        {
            return this.Delete(_cliente);
        }

        public bool Delete(Clientes cliente)
        {
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(cliente));
            try
            {
                if (cliente is null) return false;
                if (cliente.Id <= uint.MinValue) return false;

                if (!crud.Delete()) return false;

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public Clientes Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Clientes.Campos.ID}={id}";
            List<Clientes> ListaClientes = GetClientes(sql);
            if (ListaClientes.Count > 0)
            {
                return ListaClientes[0];
            }
            return null;
        }

        public List<Clientes> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetClientes(sql);
        }

        public List<Clientes> GetAll(Clientes cliente)
        {
            string sql = $"SELECT * FROM {TABELA} ";
            if (!(cliente is null))
            {
                string conditions = string.Empty;

                if (cliente.Id > 0) conditions = $" WHERE ID={cliente.Id}";

                if (!String.IsNullOrEmpty(cliente.Nome))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Clientes.Campos.NOME} LIKE '%{cliente.Nome}%'";
                }

                if (!String.IsNullOrEmpty(cliente.Email))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Clientes.Campos.EMAIL} = '{cliente.Email}'";   
                }

                if (!String.IsNullOrEmpty(cliente.Cpf))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Clientes.Campos.CPF} = '{cliente.Cpf}'";
                }

                if (!(cliente.Endereco is null))
                {
                    if (!String.IsNullOrEmpty(cliente.Endereco.Logradouro))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Clientes.Campos.LOGRADOURO} = '{cliente.Endereco.Logradouro}'";
                     
                    }

                    if (!String.IsNullOrEmpty(cliente.Endereco.Numero))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Clientes.Campos.NUMERO} = '{cliente.Endereco.Numero}'";
                    }

                    if (!String.IsNullOrEmpty(cliente.Endereco.Bairro))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Clientes.Campos.BAIRRO} = '{cliente.Endereco.Bairro}'";
                    }

                    if (!String.IsNullOrEmpty(cliente.Endereco.Cidade))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Clientes.Campos.CIDADE} = '{cliente.Endereco.Cidade}'";
                    }

                    if (!String.IsNullOrEmpty(cliente.Endereco.UF))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Clientes.Campos.UF} = '{cliente.Endereco.UF}'";
                    }
                }
                sql += conditions;
            }
            return GetClientes(sql);
        }

        public bool Insert()
        {
            return this.Insert(_cliente);
        }

        public bool Insert(Clientes cliente)
        {
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(cliente));
            try
            {
                if (cliente is null) return false;

                if (!crud.Insert()) return false;
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public bool Update()
        {
            return this.Update(_cliente);
        }

        public bool Update(Clientes cliente)
        {
            if (cliente is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(cliente));
            try
            {
                if (!crud.Update()) return false;
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                crud.Dispose();
            }
        }

        public void Dispose()
        {
            if(!(_cliente is null)) _cliente.Dispose();
        }

        #endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Clientes.Campos.ID.ToString(),
                Clientes.Campos.NOME.ToString(),
                Clientes.Campos.EMAIL.ToString(),
                Clientes.Campos.CPF.ToString(),
                Clientes.Campos.LOGRADOURO.ToString(),
                Clientes.Campos.NUMERO.ToString(),
                Clientes.Campos.BAIRRO.ToString(),
                Clientes.Campos.CIDADE.ToString(),
                Clientes.Campos.UF.ToString(),
                Clientes.Campos.CEP.ToString()
            };
            return campos;
        }

        private string[] GetValues(Clientes cliente)
        {
            string[] valores = 
            {
                cliente.Id.ToString(),
                cliente.Nome,
                cliente.Email,
                cliente.Cpf,
                cliente.Endereco.Logradouro,
                cliente.Endereco.Numero,
                cliente.Endereco.Bairro,
                cliente.Endereco.Cidade,
                cliente.Endereco.UF,
                cliente.Endereco.CEP
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Clientes.Campos.ID.ToString() };
        }

        private string[] GetValueID(Clientes cliente)
        {
            return new string[] { cliente.Id.ToString() };
        }

        private List<Clientes> GetClientes(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);
            try
            {
                List<Clientes> ListaClientes = new List<Clientes>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Clientes.Campos.ID);
                        string nome = reader.GetString((int)Clientes.Campos.NOME);
                        string email = reader.GetString((int)Clientes.Campos.EMAIL);
                        string cpf = reader.GetString((int)Clientes.Campos.CPF);
                        string cep = reader.GetString((int)Clientes.Campos.CEP);
                        string logradouro = reader.GetString((int)Clientes.Campos.LOGRADOURO);
                        string numero = reader.GetString((int)Clientes.Campos.NUMERO);
                        string bairro = reader.GetString((int)Clientes.Campos.BAIRRO);
                        string cidade = reader.GetString((int)Clientes.Campos.CIDADE);
                        string uf = reader.GetString((int)Clientes.Campos.UF);

                        ListaClientes.Add(new Clientes(id, nome, email, cpf, new Enderecos(cep, logradouro, numero, bairro, cidade, uf)));
                    }
                }
                return ListaClientes;
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

        #endregion
    }
}


