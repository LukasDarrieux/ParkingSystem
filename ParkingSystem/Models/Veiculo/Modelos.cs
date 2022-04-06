using System;

namespace ParkingSystem.Models.Veiculo
{
    class Modelos : IDisposable
    {
        public enum Campos
        {
            ID,
            IDFABRICANTE,
            NOME,
            POTENCIA,
            ANO,
            LAST = ANO
        }


        public int Id { get; private set; }
        public string Nome { get; set; }
        public double Potencia { get; set; }
        public int Ano { get; set; }
        public Fabricantes Fabricante { get; set; }

        public Modelos(int id, string nome, double potencia, int ano, Fabricantes fabricante)
        {
            this.Id = id;
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
            Id = 0;
            Nome = null;
            Potencia = 0;
            Ano = 0;
            Fabricante.Dispose();
        }
    }
}
