using ParkingSystem.Models.Veiculo;
using System;

namespace ParkingSystem.Models.Estacionamento
{
    class Estacionamentos : IDisposable
    {

        public enum Campos
        {
            ID,
            IDVAGA,
            IDVEICULO,
            ENTRADA, 
            SAIDA,
            VALORTOTAL
        }

        public int Id { get; set; }
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
    }
}
