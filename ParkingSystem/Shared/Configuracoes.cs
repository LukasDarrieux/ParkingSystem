using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Utils.Interfaces;
using ParkingSystem.Utils.Implements;


namespace ParkingSystem.Shared
{
    class Configuracoes
    {

        private static ConfiguracaoEstacionamento ConfiguracaoEstacionamento;


        public static void AtualizarConfiguracaoPersonalizacao(string titulo)
        {
            ConfiguracaoPersonalizacaoDAO configuracaoPersonalizacaoDAO = new ConfiguracaoPersonalizacaoDAO(new ConfiguracaoPersonalizacao(titulo));
            configuracaoPersonalizacaoDAO.SavePersonalization();
            configuracaoPersonalizacaoDAO.Dispose();
        }

        public static Database GetDatabase()
        {
            return ConfiguracaoDatabase.GetDatabase();
        }

        public static void LoadConfiguracaoEstacionamento()
        {
            ConfiguracaoEstacionamento = ConfiguracaoEstacionamentoDAO.LoadConfig();
        }

        public static void AtualizaConfiguracaoEstacionamento(double valorCarro, double valorMoto, double valorPerNoite)
        {
            ConfiguracaoEstacionamento = new ConfiguracaoEstacionamento(0 , valorCarro, valorMoto, valorPerNoite);
            ConfiguracaoEstacionamentoDAO.UpdateConfig(ConfiguracaoEstacionamento);
        }

        public static ConfiguracaoEstacionamento GetConfiguracaoEstacionamento()
        {
            LoadConfiguracaoEstacionamento();
            return ConfiguracaoEstacionamento;
        }

        public static ConfiguracaoPersonalizacao GetConfiguracaoPersonalizacao()
        {
            ConfiguracaoPersonalizacaoDAO configuracaoPersonalizacaoDAO = new ConfiguracaoPersonalizacaoDAO(new ConfiguracaoPersonalizacao(""));
            try
            {
                return configuracaoPersonalizacaoDAO.GetConfiguracaoPersonalizacao();
            }
            finally
            {
                configuracaoPersonalizacaoDAO.Dispose();
            }
        }
    }
}
