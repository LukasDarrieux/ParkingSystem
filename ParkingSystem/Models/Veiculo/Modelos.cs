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
            TIPO,
            LAST = TIPO
        }


        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Motor { get; set; }
        public int Ano { get; set; }
        public Fabricantes Fabricante { get; set; }

        public EnumVeiculos.tipo Tipo { get; set; }

        public Modelos()
        {

        }

        public Modelos(int id, string nome, string motor, int ano, Fabricantes fabricante, EnumVeiculos.tipo tipo)
        {
            Id = id;
            Nome = nome;
            Motor = motor;
            Ano = ano;
            Fabricante = fabricante;
            Tipo = tipo;
        }

        public Modelos(int id, string nome, string motor, int ano, Fabricantes fabricante)
        {
            Id = id;
            Nome = nome;
            Motor = motor;
            Ano = ano;
            Fabricante = fabricante;
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
                return (((Modelos)obj).Id == Id && ((Modelos)obj).Nome == Nome && ((Modelos)obj).Fabricante.Id == Fabricante.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
