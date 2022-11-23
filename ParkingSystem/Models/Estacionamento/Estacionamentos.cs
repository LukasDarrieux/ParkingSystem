using ParkingSystem.Models.Veiculo;
using ParkingSystem.Shared;
using System;

namespace ParkingSystem.Models.Estacionamento
{
    class Estacionamentos : IDisposable
    {
        private const short TOTAL_MINUTOS_DIA = 1440;

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
            DateTime dataSaida = Saida is null ? DateTime.Now : Convert.ToDateTime(Saida);
            
            double tempoTotal = (double)dataSaida.Subtract(Entrada).TotalMinutes;
            TimeSpan tempoCompleto = TimeSpan.FromMinutes(tempoTotal);

            if (tempoTotal > TOTAL_MINUTOS_DIA) return tempoCompleto.ToString(@"d\.hh\:mm\:ss");
            
            return tempoCompleto.ToString(@"hh\:mm\:ss");
         
        }

    }
}
