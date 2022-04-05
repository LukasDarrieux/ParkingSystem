using System;

namespace ParkingSystem.Models.Veiculo
{
    class Fabricantes : IDisposable
    {
        public enum Campos
        {
            ID, 
            NOME,
            LAST = NOME
        }

        public int Id { get; private set;  }
        public string Nome { get; set; }

        public Fabricantes(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public void Dispose()
        {
            Id = ushort.MinValue;
            Nome = null;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
