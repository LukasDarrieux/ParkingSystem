using System;
using ParkingSystem.Models.Pessoa;

namespace ParkingSystem.Models.Usuario
{
    class Usuarios : Pessoas, IDisposable
    {
        private const int ID_USUARIO_ADMIN = 1;

        public enum Campos
        {
            ID = 0,
            NOME,
            EMAIL,
            SENHA,
            TIPO,
            LAST = TIPO
        }

        public enum TipoUsuario
        {
            COMUM = 0,
            ADMINISTRADOR = 1
        }

        public int Id { get; private set; }
        public string Senha { get; set; }

        public TipoUsuario Tipo;

        public Usuarios(int id, string nome, string email, string senha) : base(nome, email)
        {
            Id = id;
            Senha = senha;
            Tipo = TipoUsuario.COMUM;
        }

        public Usuarios(int id, string nome, string email, string senha, TipoUsuario tipo) : base(nome, email)
        {
            Id = id;
            Senha = senha;
            Tipo = tipo;
        }

        public override void Dispose()
        {
            base.Dispose();
            Id = 0;
            Senha = null;
        }

        public bool IsAdmin()
        {
            return (Id == ID_USUARIO_ADMIN && Nome == "ADMINISTRADOR" && Email == "adm@darrieuxinfo.com");
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
