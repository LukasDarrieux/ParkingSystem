using ParkingSystem.Utils.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Shared
{
    class ConfiguracaoPersonalizacaoDAO
    {
        private ConfiguracaoPersonalizacao ConfiguracaoPersonalizacao;
        private IDatabase db;

        public ConfiguracaoPersonalizacaoDAO(ConfiguracaoPersonalizacao configuracaoPersonalizacao)
        {
            ConfiguracaoPersonalizacao = configuracaoPersonalizacao;
            db = Configuracoes.GetDatabase();
        }

        public bool SavePersonalization()
        {
            try
            {
                string sqlComando = $"UPDATE CONFIGURACOES SET TITULO = '{ConfiguracaoPersonalizacao.Titulo}'";
                db.ExecuteSql(sqlComando);
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ConfiguracaoPersonalizacao GetConfiguracaoPersonalizacao()
        {
            const int TITULO = 0;
            DbDataReader reader = null;
            try
            {
                string sqlComando = $"SELECT TITULO FROM CONFIGURACOES";
                reader = db.ExecuteQuery(sqlComando);

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return new ConfiguracaoPersonalizacao(reader.GetString(TITULO));
                    }
                }
                return null;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                if (!(reader is null)) reader = null;
            }
        }

        public void Dispose()
        {
            ConfiguracaoPersonalizacao.Dispose();
            if (!(db is null)) db = null;
        }
    }
}
