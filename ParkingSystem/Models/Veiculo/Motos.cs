using ParkingSystem.Models.Cliente;
using ParkingSystem.Shared;
using System;

namespace ParkingSystem.Models.Veiculo
{
    class Motos : Veiculos
    {
        public Motos(int id, string placa, Modelos modelo, Clientes cliente) : base(id, placa, modelo, cliente, EnumVeiculos.tipo.Carro)
        {

        }

        public override double GetSubTotal(DateTime Entrada)
        {
            double ValorTotal = 0;

            ConfiguracaoEstacionamento configEstacionamento = Configuracoes.GetConfiguracaoEstacionamento();
            DateTime saida = DateTime.Now;

            double tempoTotal = (double)saida.Subtract(Entrada).TotalMinutes;

            if (tempoTotal > TOTAL_MINUTOS_DIA)
            {
                ValorTotal = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_DIA)) * configEstacionamento.PerNoite;
            }
            else if (tempoTotal > TOTAL_MINUTOS_HORAS)
            {
                ValorTotal = (Math.Ceiling(tempoTotal / TOTAL_MINUTOS_HORAS)) * configEstacionamento.Moto;
            }
            else
            {
                ValorTotal = configEstacionamento.Moto;
            }

            return ValorTotal;
        }
    }
}
