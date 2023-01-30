using System;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Shared;

namespace ParkingSystem.Models.Veiculo
{
    class Veiculos : IDisposable
    {
        protected const short TOTAL_MINUTOS_DIA = 1440;
        protected const short TOTAL_MINUTOS_HORAS = 60;

        public enum Campos
        {
            ID,
            IDMODELO,
            IDCLIENTE,
            PLACA,
            TIPO,
            LAST = TIPO
        }

        public int Id { get; private set; }
        public string Placa { get; set; }
        public Modelos Modelo { get; set; }
        public Clientes Cliente { get; set; }
        public int Tipo { get; private set; }

        public Veiculos(int id, string placa, Modelos modelo, Clientes cliente, EnumVeiculos.tipo tipo)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Cliente = cliente;
            Tipo = (int)tipo;
        }

        public virtual void Dispose()
        {
            Id = 0;
            Placa = null;
            Cliente.Dispose();
            Modelo.Dispose();
        }

        public override string ToString()
        {
            return $"{Modelo} - {Placa}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Veiculos)
            {
                return (Id == ((Veiculos)obj).Id && Placa == ((Veiculos)obj).Placa);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual double GetSubTotal(DateTime Entrada)
        {
            return 0;
        }

    }
}
