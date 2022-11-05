using System;

namespace ParkingSystem.Models.Pessoa
{
    class Pessoas : IDisposable
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public Pessoas(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public virtual void Dispose()
        {
            Nome = null;
            Email = null;
        }
    }
}