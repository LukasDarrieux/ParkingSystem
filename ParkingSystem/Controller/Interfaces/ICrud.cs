using System;

namespace ParkingSystem.Controller.Interfaces
{
    interface ICrud
    {
        bool Insert();
        bool Delete();
        bool Update();
    }
}
