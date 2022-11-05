using ParkingSystem.Models.Estacionamento;
using System.Collections.Generic;

namespace ParkingSystem.Controller.Interfaces
{
    interface IEstacionamentosController
    {
        bool Insert(Estacionamentos estacionamento);
        bool Update(Estacionamentos estacionamento);
        bool Delete(Estacionamentos estacionamento);
        Estacionamentos Get(int id);
        List<Estacionamentos> GetAll();
        List<Estacionamentos> GetAll(Estacionamentos estacionamento);
    }
}
