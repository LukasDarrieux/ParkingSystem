using ParkingSystem.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models.Veiculo
{
    class Motos : Veiculos
    {
        public Motos(int id, string placa, Modelos modelo, Clientes cliente) : base(id, placa, modelo, cliente, EnumVeiculos.tipo.Carro)
        {

        }
    }
}
