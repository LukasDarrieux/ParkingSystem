using ParkingSystem.Controller.Interfaces;
using ParkingSystem.Models.Estacionamento;
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
    class EstacionamentosController: IEstacionamentosController, ICrud, IDisposable
    {
        #region "Atributos"

        private Estacionamentos _estacionamento;
        private Database db;
        private const string TABELA = "ESTACIONAMENTO";

        #endregion

        #region "Construtores"

        public EstacionamentosController(Estacionamentos estacionamento)
        {
            this._estacionamento = estacionamento;
            this.db = Configuracoes.GetDatabase();
        }

        public EstacionamentosController()
        {
            this.db = Configuracoes.GetDatabase();
        }

        #endregion

        #region "Métodos públicos"

        public Estacionamentos Get(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE {Estacionamentos.Campos.ID.ToString()}={id.ToString()}";
            List<Estacionamentos> listaEstacionamentos = GetEstacionamentos(sql);

            if (listaEstacionamentos is null) return null;

            if (listaEstacionamentos.Count == 1)
            {
                return listaEstacionamentos.ElementAt<Estacionamentos>(0);
            }
            return null;
        }

        public List<Estacionamentos> GetAll()
        {
            string sql = $"SELECT * FROM {TABELA}";
            return GetEstacionamentos(sql);
        }

        public List<Estacionamentos> GetAll(Estacionamentos estacionamento)
        {
            string sql = $"SELECT * FROM {TABELA}";
            if (!(estacionamento is null))
            {
                string conditions = string.Empty;

                if (estacionamento.Id > 0) conditions = $" WHERE {Estacionamentos.Campos.ID}={estacionamento.Id.ToString()}";

                if (!(estacionamento.Vaga is null))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Estacionamentos.Campos.IDVAGA} LIKE {estacionamento.Vaga.Id}";
                }

                if (General.IsDate(estacionamento.Entrada.ToString("dd-MM-yyyy")))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"{Estacionamentos.Campos.ENTRADA} >= '{estacionamento.Entrada.ToString("dd-MM-yyyy 00:00:00")}'";
                }

                if (General.IsDate(estacionamento.Saida.ToString().Replace(" 00:00:00", "")))
                {
                    if (String.IsNullOrEmpty(conditions)) conditions += $" WHERE ";
                    else conditions += $" AND ";
                    conditions += $"({Estacionamentos.Campos.SAIDA} <= '{Convert.ToDateTime(estacionamento.Saida).ToString("dd-MM-yyyy 23:59:59")}' OR SAIDA IS NULL)";
                }

                sql += conditions;
            }
            return GetEstacionamentos(sql);
        }

        public bool Insert(Estacionamentos estacionamento)
        {
            if (estacionamento is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(estacionamento));
            try
            {

                if (VagaOcupada(estacionamento))
                {
                    General.MessageShowAttention("A vaga informada está ocupada!");
                    return false;
                }

                if (!crud.Insert())
                {
                    General.MessageShowAttention("Não foi possível salvar o registro!");
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
            return Insert(_estacionamento);
        }

        public bool Update(Estacionamentos estacionamento)
        {
            if (estacionamento is null) return false;
            Crud crud = new Crud(db, TABELA, GetFields(), GetValues(estacionamento));
            try
            {
                if (!crud.Update())
                {
                    General.MessageShowAttention("Não foi possível atualizar o registro!");
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
            return Update(_estacionamento);
        }

        public bool Delete(Estacionamentos estacionamento)
        {
            if (estacionamento is null) return false;
            Crud crud = new Crud(this.db, TABELA, GetFieldID(), GetValueID(estacionamento.Id));
            try
            {
                if (estacionamento.Id <= uint.MinValue) return false;

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
            return Delete(_estacionamento);
        }

        public void Dispose()
        {
            this.db.Dispose();
            if (!(_estacionamento is null))
            {
                _estacionamento.Dispose();
            }
        }

        # endregion

        #region "Métodos privados"

        private string[] GetFields()
        {
            string[] campos =
            {
                Estacionamentos.Campos.ID.ToString(),
                Estacionamentos.Campos.IDVAGA.ToString(),
                Estacionamentos.Campos.IDVEICULO.ToString(),
                Estacionamentos.Campos.ENTRADA.ToString(),
                Estacionamentos.Campos.SAIDA.ToString(),
                Estacionamentos.Campos.VALORTOTAL.ToString()
            };

            return campos;
        }

        private string[] GetValues(Estacionamentos estacionamento)
        {
            if (estacionamento is null) return null;

            string[] valores =
            {
                estacionamento.Id.ToString(),
                estacionamento.Vaga.Id.ToString(),
                estacionamento.Veiculo.Id.ToString(),
                estacionamento.Entrada.ToString(),
                ValideSaida(estacionamento),
                estacionamento.ValorTotal.ToString().Replace(",", ".")
            };

            return valores;
        }

        private string ValideSaida(Estacionamentos estacionamento)
        {
            if (estacionamento.Saida is null) return "null";
            return estacionamento.Saida.ToString();
        }

        private string[] GetFieldID()
        {
            return new string[] { Vagas.Campos.ID.ToString() };
        }

        private string[] GetValueID(int id)
        {
            return new string[] { id.ToString() };
        }

        private List<Estacionamentos> GetEstacionamentos(string sql)
        {
            DbDataReader reader = db.ExecuteQuery(sql);

            try
            {
                List<Estacionamentos> listaEstacionamentos = null;
                if (reader.HasRows)
                {
                    listaEstacionamentos = new List<Estacionamentos>();
                    using (VagasController vagasController = new VagasController())
                    {
                        using (VeiculosController veiculosController = new VeiculosController())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetFieldValue<int>((int)Estacionamentos.Campos.ID);
                                Vagas vaga = vagasController.Get(reader.GetFieldValue<int>((int)Estacionamentos.Campos.IDVAGA));
                                Veiculos veiculo = veiculosController.Get(reader.GetFieldValue<int>((int)Estacionamentos.Campos.IDVEICULO));
                                DateTime entrada = reader.GetFieldValue<DateTime>((int)Estacionamentos.Campos.ENTRADA);

                                object obj = reader.GetFieldValue<object>((int)Estacionamentos.Campos.SAIDA);
                                DateTime? saida = null;

                                if (!(obj is null) && obj != DBNull.Value) saida = Convert.ToDateTime(obj);

                                double valor = Convert.ToDouble(reader.GetFieldValue<decimal>((int)Estacionamentos.Campos.VALORTOTAL));

                                listaEstacionamentos.Add(new Estacionamentos(id, vaga, veiculo, entrada, saida, valor));

                            }
                        }
                    }
                }
                return listaEstacionamentos;
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

        private bool VagaOcupada(Estacionamentos estacionamentos)
        {
            try
            {
                string sqlComando = $"SELECT * FROM ESTACIONAMENTO WHERE {Estacionamentos.Campos.IDVAGA} = {estacionamentos.Vaga.Id} AND SAIDA IS NULL";
                return (!(GetEstacionamentos(sqlComando) is null));
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        #endregion
    }
}
