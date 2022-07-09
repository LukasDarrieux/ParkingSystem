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
            MOTOR,
            ANO,
            LAST = ANO
        }


        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Motor { get; set; }
        public int Ano { get; set; }
        public Fabricantes Fabricante { get; set; }

        public Modelos()
        {

        }

        public Modelos(int id, string nome, string motor, int ano, Fabricantes fabricante)
        {
            this.Id = id;
            this.Nome = nome;
            this.Motor = motor;
            this.Ano = ano;
            this.Fabricante = fabricante;
        }

        public override string ToString()
        {
            return $"{Nome} - {Motor}";
        }

        public void Dispose()
        {
            Id = 0;
            Nome = null;
            Motor = null;
            Ano = 0;
            if (!(Fabricante is null))
            {
                Fabricante.Dispose();
            }
            
        }

        public override bool Equals(object obj)
        {
            if (obj is Modelos)
            {
                return (((Modelos)obj).Id != this.Id && ((Modelos)obj).Nome == this.Nome && ((Modelos)obj).Fabricante.Id == this.Fabricante.Id);
            }
            return false;
        }
    }
}
