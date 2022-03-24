using System;

namespace ParkingSystem.Models.Veiculo
{
    class Modelos : IDisposable
    {
        public string Nome { get; set; }
        public double Potencia { get; set; }
        public int Ano { get; set; }
        public Fabricantes Fabricante { get; set; }

        public Modelos(string nome, double potencia, int ano, Fabricantes fabricante)
        {
            this.Nome = nome;
            this.Potencia = potencia;
            this.Ano = ano;
            this.Fabricante = fabricante;
        }

        public override string ToString()
        {
            return Nome;
        }

        public void Dispose()
        {
            Nome = null;
            Potencia = 0;
            Ano = 0;
            Fabricante.Dispose();
        }
    }
}
