using System.Collections.Generic;
using ParkingSystem.Models.Veiculo;

namespace ParkingSystem.Controller.Interfaces
{
    interface IFabricantesController
    {
        bool Insert(Fabricantes fabricante);
        bool Update(Fabricantes fabricante);
        bool Delete(Fabricantes fabricante);
        Fabricantes Get(int id);
        List<Fabricantes> GetAll();
        List<Fabricantes> GetAll(Fabricantes fabricante);
    }
}
