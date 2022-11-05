using System.Collections.Generic;
using ParkingSystem.Models.Cliente;

namespace ParkingSystem.Controller.Interfaces
{
    interface IClientesController
    {
        bool Insert(Clientes cliente);
        bool Update(Clientes cliente);
        bool Delete(Clientes cliente);
        Clientes Get(int id);
        List<Clientes> GetAll();
        List<Clientes> GetAll(Clientes cliente);
    }
}
