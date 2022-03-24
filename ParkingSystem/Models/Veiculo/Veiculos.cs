using System;
using ParkingSystem.Models.Cliente;

namespace ParkingSystem.Models.Veiculo
{
    class Veiculos : IDisposable
    {
        public string Placa { get; set; }
        public Modelos Modelo { get; set; }
        public Clientes Cliente { get; set; }

        public Veiculos(string placa, Modelos modelo, Clientes cliente)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Cliente = cliente;
        }

        public virtual void Dispose()
        {
            Placa = null;
            Cliente.Dispose();
            Modelo.Dispose();
        }
    }
}
