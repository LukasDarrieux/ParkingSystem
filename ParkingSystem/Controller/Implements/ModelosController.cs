using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Veiculo;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ParkingSystem.Controller.Implements
{
    class ModelosController : IModelosController, ICrud, IDisposable
    {
        #region "Atributos"

        private readonly Modelos _modelo;
        private readonly Database db;
        private const string TABELA = "MODELOS";

        #endregion

        #region "Construtores"

        public ModelosController(Modelos modelo)
        {
            this._modelo = modelo;
            this.db = Configuracoes.GetDatabase();
        }

        public ModelosController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public bool Delete(Modelos modelo)
        {
            if (modelo is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(modelo.Id));
            try
            {
                if (modelo.Id <= uint.MinValue) return false;

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
            return Delete(_modelo);
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_modelo is null))
            {
                _modelo.Dispose();
            }
        }

        public Modelos Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Modelos.Campos.ID}={id}";
            List<Modelos> listaModelos = GetModelos(sql);

            if (listaModelos is null) return null;

            if (listaModelos.Count == 1)
            {
                return listaModelos.ElementAt<Modelos>(0);
            }
            return null;
        }

        public List<Modelos> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetModelos(sql);
        }

        public List<Modelos> GetAll(Modelos modelo)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(modelo is null))
            {
                string conditions = string.Empty;

                if (modelo.Id > 0) conditions = $" WHERE ID={modelo.Id}";

                if (!String.IsNullOrEmpty(modelo.Nome))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Modelos.Campos.NOME} LIKE '{modelo.Nome}%'";
                }

                if (!String.IsNullOrEmpty(modelo.Motor))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Modelos.Campos.MOTOR} LIKE '{modelo.Motor}%'";
                }

                if (!(modelo.Fabricante is null))
                {
                    if (modelo.Fabricante.Id > 0)
                    {
                        if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                        else conditions += $" AND ";
                        conditions += $"{Modelos.Campos.IDFABRICANTE} = {modelo.Fabricante.Id}";
                    }
                }

                if (modelo.Ano > 0)
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Modelos.Campos.ANO} = {modelo.Ano}";
                }

                sql += conditions;
            }
            return GetModelos(sql);
        }

        public bool Insert(Modelos modelo)
        {
            if (modelo is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(modelo));
            try
            {
                if (ModeloExists(modelo))
                {
                    General.MessageShowAttention("Modelo já cadastrado!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar modelo!");
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
            return Insert(_modelo);
        }

        public bool Update(Modelos modelo)
        {
            if (modelo is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(modelo));
            try
            {
                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar modelo!");
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
            return Update(_modelo);
        }

        #endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Modelos.Campos.ID.ToString(),
                Modelos.Campos.IDFABRICANTE.ToString(),
                Modelos.Campos.NOME.ToString(),
                Modelos.Campos.MOTOR.ToString(),
                Modelos.Campos.ANO.ToString(),
                Modelos.Campos.TIPO.ToString()
            };

            return campos;
        }

        private string[] GetValues(Modelos modelo)
        {
            if (modelo is null) return null;

            string[] valores =
            {
                modelo.Id.ToString(),
                modelo.Fabricante.Id.ToString(),
                modelo.Nome,
                modelo.Motor,
                modelo.Ano.ToString(),
                ((int)modelo.Tipo).ToString()
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Modelos.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Modelos> GetModelos(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);
            FabricantesController fabricanteController = new FabricantesController();
            try
            {
                List<Modelos> listaModelos = null;
                if (reader.HasRows)
                {
                    listaModelos = new List<Modelos>();

                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Modelos.Campos.ID);
                        string nome = reader.GetString((int)Modelos.Campos.NOME);
                        string motor = reader.GetString((int)Modelos.Campos.MOTOR);
                        int ano = reader.GetFieldValue<int>((int)Modelos.Campos.ANO);
                        Fabricantes fabricante = fabricanteController.Get(reader.GetFieldValue<int>((int)Modelos.Campos.IDFABRICANTE));
                        EnumVeiculos.tipo tipo = (EnumVeiculos.tipo)reader.GetFieldValue<int>((int)Modelos.Campos.TIPO);

                        if (!(fabricante is null))
                        {
                            listaModelos.Add(new Modelos(id, nome, motor, ano, fabricante, tipo));
                        }
                    }
                }
                return listaModelos;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                fabricanteController.Dispose();
                reader.Close();
                reader.Dispose();
            }
        }

        private bool ModeloExists(Modelos modelo)
        {
            List<Modelos> listaModelos = null;
            try
            {
                listaModelos = this.GetAll(modelo);

                if (listaModelos is null) return false;

                return listaModelos.Contains(modelo);
            }
            finally
            {
                if (!(listaModelos is null))
                {
                    listaModelos.Clear();
                }

            }

        }

        #endregion
    }
}
