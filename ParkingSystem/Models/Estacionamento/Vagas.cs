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
            this.Id = id;
            this.Vaga = vaga;
        }

        public void Dispose()
        {
            this.Id = 0;
            this.Vaga = null;
        }

        public override string ToString()
        {
            return $"{this.Vaga}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vagas)) return false;
            return  ((Vagas)obj).Vaga == this.Vaga;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
