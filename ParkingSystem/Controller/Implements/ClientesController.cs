using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Utils.Interfaces;
using ParkingSystem.Shared;
using ParkingSystem.Models.Pessoa;
using ParkingSystem.Utils.Implements;
using System.Data.Common;

namespace ParkingSystem.Controller.Implements
{
    class ClientesController : IClientesController, ICrud, IDisposable
    {

        #region "Atributos"

        private Clientes _cliente;
        private IDatabase db;
        private const string TABELA = "CLIENTES";

        #endregion

        #region "Construtores"

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
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID());
            try
            {
                if (cliente is null) return false;
                if (cliente.Id >= uint.MinValue) return false;

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
            string sql = $"SELECT * FROM {TABELA} WHERE {Clientes.Campos.ID.ToString()}={id.ToString()}";
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string nome = reader.GetString((int)Clientes.Campos.NOME);
                        string email = reader.GetString((int)Clientes.Campos.EMAIL);
                        string cpf = reader.GetString((int)Clientes.Campos.CPF);
                        string logradouro = reader.GetString((int)Clientes.Campos.LOGRADOURO);
                        string numero = reader.GetString((int)Clientes.Campos.NUMERO);
                        string bairro = reader.GetString((int)Clientes.Campos.BAIRRO);
                        string cidade = reader.GetString((int)Clientes.Campos.CIDADE);
                        string uf = reader.GetString((int)Clientes.Campos.UF);

                        _cliente = new Clientes(id, nome, email, cpf, new Enderecos(logradouro, numero, bairro, cidade, uf));       
                    }
                }
                return _cliente;
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

        public List<Clientes> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                List<Clientes> ListaClientes = new List<Clientes>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt16((int)Clientes.Campos.ID);
                        string nome = reader.GetString((int)Clientes.Campos.NOME);
                        string email = reader.GetString((int)Clientes.Campos.EMAIL);
                        string cpf = reader.GetString((int)Clientes.Campos.CPF);
                        string logradouro = reader.GetString((int)Clientes.Campos.LOGRADOURO);
                        string numero = reader.GetString((int)Clientes.Campos.NUMERO);
                        string bairro = reader.GetString((int)Clientes.Campos.BAIRRO);
                        string cidade = reader.GetString((int)Clientes.Campos.CIDADE);
                        string uf = reader.GetString((int)Clientes.Campos.UF);

                        ListaClientes.Add(new Clientes(id, nome, email, cpf, new Enderecos(logradouro, numero, bairro, cidade, uf)));
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

        public List<Clientes> GetAll(Clientes cliente)
        {
            throw new NotImplementedException();
        }

        public bool Insert()
        {
            return this.Insert(_cliente);
        }

        public bool Insert(Clientes cliente)
        {
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues());
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
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues());
            try
            {
                if (cliente is null) return false;

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
            string[] campos = new string[(int)Clientes.Campos.LAST];

            foreach (Clientes.Campos fields in Enum.GetValues(typeof(Clientes.Campos)))
            {
                if (fields != Clientes.Campos.LAST)
                {
                    campos[(int)fields] = fields.ToString();
                }
            }
            return campos;
        }

        private string[] GetValues()
        {
            string[] valores = 
            {
                _cliente.Id.ToString(),
                _cliente.Nome,
                _cliente.Email,
                _cliente.Cpf,
                _cliente.Endereco.Logradouro,
                _cliente.Endereco.Numero,
                _cliente.Endereco.Cidade,
                _cliente.Endereco.UF
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Clientes.Campos.ID.ToString() };
        }

        private string[] GetValueID()
        {
            return new string[] { _cliente.Id.ToString() };
        }

        #endregion
    }
}
