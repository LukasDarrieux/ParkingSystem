using ParkingSystem.Models.Veiculo;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Controller.Implements
{
    class VeiculosController : IDisposable
    {
        #region "Atributos"

        private Veiculos _veiculo;
        private Database db;
        private const string TABELA = "VEICULOS";

        #endregion

        #region "Construtores"

        public VeiculosController(Veiculos veiculo)
        {
            this._veiculo = veiculo;
            this.db = Configuracoes.GetDatabase();
        }

        public VeiculosController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public bool Delete(Veiculos veiculo)
        {
            if (veiculo is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(veiculo.Id));
            try
            {
                if (veiculo.Id <= uint.MinValue) return false;

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

        public bool Delete()
        {
            return Delete(_veiculo);
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_veiculo is null))
            {
                _veiculo.Dispose();
            }
        }

        public Veiculos Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Veiculos.Campos.ID.ToString()}={id.ToString()}";
            List<Veiculos> listaVeiculos = GetVeiculos(sql);

            if (listaVeiculos is null) return null;

            if (listaVeiculos.Count == 1)
            {
                return listaVeiculos.ElementAt<Veiculos>(0);
            }
            return null;
        }

        public List<Veiculos> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetVeiculos(sql);
        }

        public List<Veiculos> GetAll(Veiculos veiculo)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(veiculo is null))
            {
                string conditions = string.Empty;

                if (veiculo.Id > 0) conditions = $" WHERE ID={veiculo.Id.ToString()}";

                if (!String.IsNullOrEmpty(veiculo.Placa))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Veiculos.Campos.PLACA} LIKE '{veiculo.Placa}%'";
                }

                if (!(veiculo.Cliente is null))
                {
                    if (veiculo.Cliente.Id > 0)
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Veiculos.Campos.IDCLIENTE} = '{veiculo.Cliente.Id.ToString()}'";
                    }
                }


                if (!(veiculo.Modelo is null))
                {
                    string filter = "";

                    if (!(veiculo.Modelo.Fabricante is null))
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        filter = $"{Veiculos.Campos.IDMODELO} IN (SELECT ID FROM MODELOS WHERE IDFABRICANTE = {veiculo.Modelo.Fabricante.Id})";
                    }

                    if (veiculo.Modelo.Id > 0)
                    {
                        if (String.IsNullOrEmpty(filter))
                        {
                            if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                            else conditions += $" AND ";
                        }
                        filter = $"{Veiculos.Campos.IDMODELO} = '{veiculo.Modelo.Id.ToString()}'";
                    }

                    conditions += filter;
                }

                sql += conditions;
            }
            return GetVeiculos(sql);
        }

        public bool Insert(Veiculos veiculo)
        {
            if (veiculo is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(veiculo));
            try
            {
                if (VeiculosExists(veiculo))
                {
                    General.MessageShowAttention("Veiculo já cadastrado!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar veiculo!");
                    return false;
                }
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

        public bool Insert()
        {
            return Insert(_veiculo);
        }

        public bool Update(Veiculos veiculo)
        {
            if (veiculo is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(veiculo));
            try
            {
                if (veiculo is null) return false;

                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar veiculo!");
                    return false;
                }
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
            return Update(_veiculo);
        }

        #endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Veiculos.Campos.ID.ToString(),
                Veiculos.Campos.IDMODELO.ToString(),
                Veiculos.Campos.IDCLIENTE.ToString(),
                Veiculos.Campos.PLACA.ToString(),
                Veiculos.Campos.TIPO.ToString()
            };

            return campos;
        }

        private string[] GetValues(Veiculos veiculo)
        {
            if (veiculo is null) return null;

            string[] valores =
            {
                veiculo.Id.ToString(),
                veiculo.Modelo.Id.ToString(),
                veiculo.Cliente.Id.ToString(),
                veiculo.Placa,
                veiculo.Tipo.ToString()
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Veiculos.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Veiculos> GetVeiculos(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);
            ClientesController clienteController = new ClientesController();
            ModelosController modeloController = new ModelosController();

            try
            {
                List<Veiculos> listaVeiculos = null;
                if (reader.HasRows)
                {
                    listaVeiculos = new List<Veiculos>();

                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Veiculos.Campos.ID);
                        int idModelo = reader.GetFieldValue<int>((int)Veiculos.Campos.IDMODELO);
                        int idCliente = reader.GetFieldValue<int>((int)Veiculos.Campos.IDCLIENTE);
                        string placa = reader.GetString((int)Veiculos.Campos.PLACA);
                        EnumVeiculos.tipo tipo = (EnumVeiculos.tipo)reader.GetFieldValue<int>((int)Veiculos.Campos.TIPO);

                        switch (tipo)
                        {
                            case EnumVeiculos.tipo.Carro:
                                listaVeiculos.Add(new Carros(id, placa, modeloController.Get(idModelo), clienteController.Get(idCliente)));
                                break;
                            case EnumVeiculos.tipo.Moto:
                                listaVeiculos.Add(new Motos(id, placa, modeloController.Get(idModelo), clienteController.Get(idCliente)));
                                break;
                        }
                    }
                }
                return listaVeiculos;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                clienteController.Dispose();
                modeloController.Dispose();
                reader.Close();
                reader.Dispose();
            }
        }

        private bool VeiculosExists(Veiculos veiculo)
        {
            List<Veiculos> listaVeiculos = null;
            try
            {
                listaVeiculos = this.GetAll(veiculo);

                if (listaVeiculos is null) return false;

                return listaVeiculos.Contains(veiculo);
            }
            finally
            {
                if (!(listaVeiculos is null))
                {
                    listaVeiculos.Clear();
                    listaVeiculos = null;
                }

            }
        }

        #endregion
    }
}

