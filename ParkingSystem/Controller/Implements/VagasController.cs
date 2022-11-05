using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Estacionamento;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ParkingSystem.Controller.Implements
{
    class VagasController : IVagasController, ICrud, IDisposable
    {
        #region "Atributos"

        private readonly Vagas _vaga;
        private readonly Database db;
        private const string TABELA = "VAGAS";

        #endregion

        #region "Construtores"

        public VagasController(Vagas vaga)
        {
            this._vaga = vaga;
            this.db = Configuracoes.GetDatabase();
        }

        public VagasController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public Vagas Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Vagas.Campos.ID}={id}";
            List<Vagas> listaVagas = GetVagas(sql);

            if (listaVagas is null) return null;

            if (listaVagas.Count == 1)
            {
                return listaVagas.ElementAt<Vagas>(0);
            }
            return null;
        }

        public List<Vagas> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetVagas(sql);
        }

        public List<Vagas> GetAll(Vagas vaga)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(vaga is null))
            {
                string conditions = string.Empty;

                if (vaga.Id > 0) conditions = $" WHERE ID={vaga.Id}";

                if (!String.IsNullOrEmpty(vaga.Vaga))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Vagas.Campos.VAGA} LIKE '{vaga.Vaga}%'";
                }

                sql += conditions;
            }
            return GetVagas(sql);
        }

        public bool Insert(Vagas vaga)
        {
            if (vaga is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(vaga));
            try
            {
                if (VagaExists(vaga))
                {
                    General.MessageShowAttention("Vaga já cadastrado!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar a vaga!");
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
            return Insert(_vaga);
        }

        public bool Update(Vagas vaga)
        {
            if (vaga is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(vaga));
            try
            {
                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar a vaga!");
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
            return Update(_vaga);
        }

        public bool Delete(Vagas vaga)
        {
            if (vaga is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(vaga.Id));
            try
            {
                if (vaga.Id <= uint.MinValue) return false;

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
            return Delete(_vaga);
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_vaga is null))
            {
                _vaga.Dispose();
            }
        }

        # endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Vagas.Campos.ID.ToString(),
                Vagas.Campos.VAGA.ToString()
            };

            return campos;
        }

        private string[] GetValues(Vagas vaga)
        {
            if (vaga is null) return null;

            string[] valores =
            {
                vaga.Id.ToString(),
                vaga.Vaga
            };

            return valores;
        }

        private string[] GetFieldID()
        {
            return new string[] { Vagas.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Vagas> GetVagas(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                List<Vagas> listaVagas = null;
                if (reader.HasRows)
                {
                    listaVagas = new List<Vagas>();

                    while (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)Vagas.Campos.ID);
                        string vaga = reader.GetString((int)Vagas.Campos.VAGA);

                        listaVagas.Add(new Vagas(id, vaga));

                    }
                }
                return listaVagas;
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

        private bool VagaExists(Vagas vaga)
        {
            List<Vagas> listaVagas = null;
            try
            {
                listaVagas = this.GetAll(vaga);

                if (listaVagas is null) return false;

                return listaVagas.Contains(vaga);
            }
            finally
            {
                if (!(listaVagas is null))
                {
                    listaVagas.Clear();
                }

            }

        }
        
        #endregion
    }
}
