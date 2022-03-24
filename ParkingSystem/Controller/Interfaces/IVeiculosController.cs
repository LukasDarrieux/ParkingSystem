﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Models.Veiculo;

namespace ParkingSystem.Controller.Interfaces
{
    interface IVeiculosController
    {
        bool Insert(Veiculos veiculo);
        bool Update(Veiculos veiculo);
        bool Delete(Veiculos veiculo);
        Veiculos Get(int id);
        List<Veiculos> GetAll();
        List<Veiculos> GetAll(Veiculos veiculos);
    }
}
