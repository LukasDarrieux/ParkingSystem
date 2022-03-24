using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Controller.Interfaces
{
    interface ICrud
    {
        bool Insert();
        bool Delete();
        bool Update();
    }
}
