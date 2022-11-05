using ParkingSystem.Models.Estacionamento;
using System.Collections.Generic;

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
