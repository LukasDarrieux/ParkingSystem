using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models.Estacionamento
{
    class Vagas : IDisposable
    {
        public enum Campos
        {
            ID,
            VAGA
        }

        public int Id { get; set; }
        public string Vaga { get; set; }


        public Vagas()
        {

        }

        public Vagas(int id, string vaga)
        {
            this.Id = id;
            this.Vaga = vaga;
        }

        public void Dispose()
        {
            this.Id = 0;
            this.Vaga = null;
        }
    }
}
