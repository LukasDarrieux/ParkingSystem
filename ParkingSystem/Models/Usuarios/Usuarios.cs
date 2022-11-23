using System;
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
            Id = id;
            Senha = senha;
        }

        public override void Dispose()
        {
            base.Dispose();
            Id = 0;
            Senha = null;
        }

        public bool IsAdmin()
        {
            return (Id == 1 && Nome == "ADMINISTRADOR" && Email == "adm@darrieuxinfo.com");
        }

        public override bool Equals(object obj)
        {
            if (obj is Usuarios)
            {
                return (Id == ((Usuarios)obj).Id && Email == ((Usuarios)obj).Email);
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Nome}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
