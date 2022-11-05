using System.Collections.Generic;
using ParkingSystem.Models.Veiculo;

namespace ParkingSystem.Controller.Interfaces
{
    interface IModelosController
    {
        bool Insert(Modelos modelo);
        bool Update(Modelos modelo);
        bool Delete(Modelos modelo);
        Modelos Get(int id);
        List<Modelos> GetAll();
        List<Modelos> GetAll(Modelos modelo);
    }
}
