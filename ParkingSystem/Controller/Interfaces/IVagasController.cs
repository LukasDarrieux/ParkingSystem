using ParkingSystem.Models.Estacionamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Controller.Interfaces
{
    interface IVagasController
    {
        bool Insert(Vagas vaga);
        bool Update(Vagas vaga);
        bool Delete(Vagas vaga);
        Vagas Get(int id);
        List<Vagas> GetAll();
        List<Vagas> GetAll(Vagas vaga);
    }
}
