using ParkingSystem.Models.Usuario;
using ParkingSystem.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Shared
{
    internal class ConfiguracaoEstacionamentoDAO
    {
        public static bool UpdateConfig(ConfiguracaoEstacionamento config)
        {
            IDatabase db = Configuracoes.GetDatabase();
            try
            {
                string sqlComando = $"UPDATE CONFIGURACOES SET CARRO = {General.FormatValue(config.Carro)}, MOTO = {General.FormatValue(config.Moto)}, PERNOITE = {General.FormatValue(config.PerNoite)}";
                db.ExecuteSql(sqlComando);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(db is null)) db = null;
            }
        }

        public static ConfiguracaoEstacionamento LoadConfig()
        {
            IDatabase db = Configuracoes.GetDatabase();
            DbDataReader reader = null;
            try
            {
                string sqlComando = $"SELECT ID, CARRO, MOTO, PERNOITE FROM CONFIGURACOES";
                reader = db.ExecuteQuery(sqlComando);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        int id = reader.GetFieldValue<int>((int)ConfiguracaoEstacionamento.Campos.ID);
                        double valorCarro = Convert.ToDouble(reader.GetFieldValue<decimal>((int)ConfiguracaoEstacionamento.Campos.CARRO));
                        double valorMoto = Convert.ToDouble(reader.GetFieldValue<decimal>((int)ConfiguracaoEstacionamento.Campos.MOTO));
                        double valorPerNoite = Convert.ToDouble(reader.GetFieldValue<decimal>((int)ConfiguracaoEstacionamento.Campos.PERNOITE));

                        return new ConfiguracaoEstacionamento(id, valorCarro, valorMoto, valorPerNoite);
                    }
                }
                return null;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally 
            {
                if (!(db is null)) db = null;
                if (!(reader is null)) reader = null;
            }
        }
    }
}
