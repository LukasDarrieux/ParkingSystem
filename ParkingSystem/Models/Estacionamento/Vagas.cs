using System;

namespace ParkingSystem.Models.Estacionamento
{
    class Vagas : IDisposable
    {
        public enum Campos
        {
            ID,
            VAGA
        }

        public int Id { get; set; }
        public string Vaga { get; set; }


        public Vagas()
        {

        }

        public Vagas(int id, string vaga)
        {
            Id = id;
            Vaga = vaga;
        }

        public void Dispose()
        {
            Id = 0;
            Vaga = null;
        }

        public override string ToString()
        {
            return $"{Vaga}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vagas)) return false;
            return  ((Vagas)obj).Vaga == Vaga;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
