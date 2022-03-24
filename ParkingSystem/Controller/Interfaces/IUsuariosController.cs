using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Models.Usuario;

namespace ParkingSystem.Controller.Interfaces
{
    interface IUsuariosController
    {
        bool Insert(Usuarios usuario);
        bool Update(Usuarios usuario);
        bool Delete(Usuarios usuario);
        Usuarios Get(int id);
        List<Usuarios> GetAll();
        List<Usuarios> GetAll(Usuarios usuarios);
    }
}
