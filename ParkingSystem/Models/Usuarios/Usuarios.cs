using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Models.Pessoa;

namespace ParkingSystem.Models.Usuario
{
    class Usuarios : Pessoas, IDisposable
    {
        public enum Campos
        {
            ID = 0,
            NOME,
            EMAIL,
            SENHA,
            LAST = SENHA
        }

        public int Id { get; private set; }
        public string Senha { get; set; }

        public Usuarios(int id, string nome, string email, string senha) : base(nome, email)
        {
            this.Id = id;
            this.Senha = senha;
        }

        public override void Dispose()
        {
            base.Dispose();
            this.Id = 0;
            this.Senha = null;
        }

        public bool IsAdmin()
        {
            return (this.Id == 1 && this.Nome == "ADMINISTRADOR" && this.Email == "adm@darrieuxinfo.com");
        }

        public override bool Equals(object obj)
        {
            if (obj is Usuarios)
            {
                return (this.Id == ((Usuarios)obj).Id && this.Email == ((Usuarios)obj).Email);
            }
            return false;
        }
    }
}
