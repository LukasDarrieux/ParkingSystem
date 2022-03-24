using System;
using ParkingSystem.Models.Cliente;

namespace ParkingSystem.Models.Veiculo
{
    class Carros : Veiculos, IDisposable
    {
        public int Id { get; private set; }
        public int Tipo { get; private set; }

        public Carros(int id, string placa, Modelos modelo, Clientes cliente) : base(placa, modelo, cliente)
        {
            this.Id = id;
            this.Tipo = (int)EnumVeiculos.tipo.Carro;
        }

        public override void Dispose()
        {
            base.Dispose();
            Id = 0;
        }
    }
}