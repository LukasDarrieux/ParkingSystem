using System;
using ParkingSystem.Models.Pessoa;

namespace ParkingSystem.Models.Cliente
{
    class Clientes : Pessoas, IDisposable
    {
        public enum Campos
        {
            ID,
            NOME,
            EMAIL, 
            CPF,
            LOGRADOURO,
            NUMERO,
            BAIRRO,
            CIDADE,
            UF,
            LAST = UF
        }

        public int Id { get; private set; }
        public string Cpf { get; set; }
        public Enderecos Endereco { get; set; }

        public Clientes(int id, string nome, string email, string cpf, Enderecos endereco) : base(nome, email)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Endereco = endereco;
        }

        public override void Dispose()
        {
            Id = 0;
            base.Dispose();
            Endereco.Dispose();
        }
    }
}
