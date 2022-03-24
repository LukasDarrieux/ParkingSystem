using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
