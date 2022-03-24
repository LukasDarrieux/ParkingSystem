using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ParkingSystem.Utils.Interfaces
{
    interface IDatabase
    {
        void OpenConnection();
        void CloseConnection();
        void ExecuteSql(string sql);
        DbDataReader ExecuteQuery(string sqlQuery);
        bool IsConnected();
    }
}
