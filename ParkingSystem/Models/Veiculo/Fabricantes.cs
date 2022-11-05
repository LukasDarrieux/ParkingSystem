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
            Id = id;
            Nome = nome;
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

        public override bool Equals(object obj)
        {
            if (obj is Fabricantes)
            {
                return (Id == ((Fabricantes)obj).Id && Nome == ((Fabricantes)obj).Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
