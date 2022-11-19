using ParkingSystem.Models.Veiculo;
using ParkingSystem.Shared;
using System;

namespace ParkingSystem.Models.Estacionamento
{
    class Estacionamentos : IDisposable
    {
        const short TOTAL_MINUTOS_DIA = 1440;
        const short TOTAL_MINUTOS_HORAS = 60;
        public enum Campos
        {
            ID,
            IDVAGA,
            IDVEICULO,
            ENTRADA, 
            SAIDA,
            VALORTOTAL
        }

        public int Id { get; private set; }
        public Vagas Vaga { get; set; }
        public Veiculos Veiculo { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public double ValorTotal { get; set; }
        

        public Estacionamentos()
        {

        }

        public Estacionamentos(int id, Vagas vaga, Veiculos veiculo, DateTime entrada, DateTime? saida, double valor)
        {
            Id = id;
            Vaga = vaga;
            Veiculo = veiculo;
            Entrada = entrada;
            Saida = saida;
            ValorTotal = valor;
        }

        public void Dispose()
        {
            Id = 0;
            if (!(Vaga is null)) Vaga.Dispose();
            if (!(Veiculo is null)) Veiculo.Dispose();
            ValorTotal = 0;
        }

        public string GetTotalHoras()
        {
            string retorno = string.Empty;
            
            DateTime dataSaida = Saida is null ? DateTime.Now : Convert.ToDateTime(Saida);
            
            double tempoTotal = (double)dataSaida.Subtract(Entrada).TotalMinutes;
            
            if (tempoTotal > TOTAL_MINUTOS_DIA)
            {
                double totalDias = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_DIA));
                retorno = $"{totalDias} Dia";
                if (totalDias > 1) retorno = $"{totalDias} Dias";
            }
            else if (tempoTotal > TOTAL_MINUTOS_HORAS)
            {
                double totalHoras = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_HORAS));
                retorno = $"{tempoTotal.ToString("00")}:00:00";
            }
            else
            {
                retorno = $"00:{tempoTotal.ToString("00")}:00";
            }

            return retorno;
        }

        public double GetSubTotal()
        {
            ConfiguracaoEstacionamento configEstacionamento = Configuracoes.GetConfiguracaoEstacionamento();
            
            DateTime saida = DateTime.Now;
            Saida = saida;
            double tempoTotal = (double)saida.Subtract(Entrada).TotalMinutes;
            
            if (tempoTotal > TOTAL_MINUTOS_DIA)
            {
                ValorTotal = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_DIA)) * configEstacionamento.PerNoite;
            }
            else if (tempoTotal > TOTAL_MINUTOS_HORAS)
            {
                ValorTotal = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_HORAS)) * configEstacionamento.Carro;
            }
            else
            {
                ValorTotal = configEstacionamento.Carro;
            }
            
            return ValorTotal;
        }
    }
}
