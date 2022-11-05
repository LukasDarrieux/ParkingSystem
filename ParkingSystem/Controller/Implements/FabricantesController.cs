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
    class FabricantesController : IFabricantesController, ICrud, IDisposable
    {
        #region "Atributos"

        private readonly Fabricantes _fabricante;
        private readonly Database db;
        private const string TABELA = "FABRICANTES";

        #endregion

        #region "Construtores"

        public FabricantesController(Fabricantes fabricante)
        {
            this._fabricante = fabricante;
            this.db = Configuracoes.GetDatabase();
        }

        public FabricantesController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public bool Delete(Fabricantes fabricante)
        {
            if (fabricante is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(fabricante.Id));
            try
            {
                if (fabricante.Id <= uint.MinValue) return false;

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
            return Delete(_fabricante);
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_fabricante is null))
            {
                _fabricante.Dispose();
            }
        }

        public Fabricantes Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Fabricantes.Campos.ID}={id}";
            List<Fabricantes> listaFabricantes = GetFabricantes(sql);

            if (listaFabricantes is null) return null;

            if (listaFabricantes.Count == 1)
            {
                return listaFabricantes.ElementAt<Fabricantes>(0);
            }
            return null;
        }

        public List<Fabricantes> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetFabricantes(sql);
        }

        public List<Fabricantes> GetAll(Fabricantes fabricante)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(fabricante is null))
            {
                string conditions = string.Empty;

                if (fabricante.Id > 0) conditions = $" WHERE ID={fabricante.Id}";

                if (!String.IsNullOrEmpty(fabricante.Nome))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Fabricantes.Campos.NOME} LIKE '{fabricante.Nome}%'";
                }

                sql += conditions;
            }
            return GetFabricantes(sql);
        }

        public bool Insert(Fabricantes fabricante)
        {
            if (fabricante is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(fabricante));
            try
            {
                if (FabricanteExists(fabricante))
                {
                    General.MessageShowAttention("Fabricante já cadastrado!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar fabricante!");
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
            return Insert(_fabricante);
        }

        public bool Update(Fabricantes fabricante)
        {
            if (fabricante is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(fabricante));
            try
            {
                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar fabricante!");
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
            return Update(_fabricante);
        }

        #endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Fabricantes.Campos.ID.ToString(),
                Fabricantes.Campos.NOME.ToString()
            };

            return campos;
        }

        private string[] GetValues(Fabricantes fabricante)
        {
            if (fabricante is null) return null;

            string[] valores =
            {
                fabricante.Id.ToString(),
                fabricante.Nome
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Fabricantes.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Fabricantes> GetFabricantes(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                List<Fabricantes> listaFabricantes = null;
                if (reader.HasRows)
                {
                    listaFabricantes = new List<Fabricantes>();

                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Fabricantes.Campos.ID);
                        string nome = reader.GetString((int)Fabricantes.Campos.NOME);
                        
                        listaFabricantes.Add(new Fabricantes(id, nome));

                    }
                }
                return listaFabricantes;
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

        private bool FabricanteExists(Fabricantes fabricante)
        {
            List<Fabricantes> listaFabricantes = null;
            try
            {
                listaFabricantes = this.GetAll(fabricante);

                if (listaFabricantes is null) return false;

                return listaFabricantes.Contains(fabricante);
            }
            finally
            {
                if (!(listaFabricantes is null))
                {
                    listaFabricantes.Clear();
                }

            }

        }

        #endregion
    }
}
