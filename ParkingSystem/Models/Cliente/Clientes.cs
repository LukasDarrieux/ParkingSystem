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
            CEP,
            LAST = CEP
        }

        private string _cpf = String.Empty;

        public int Id { get; private set; }

        public string Cpf
        {
            get => _cpf;
            set => _cpf = removeMaskCPF(value);
            
        }
        public Enderecos Endereco { get; set; }

        public Clientes(int id, string nome, string email, string cpf, Enderecos endereco) : base(nome, email)
        {
            this.Id = id;
            this._cpf = removeMaskCPF(cpf);
            this.Endereco = endereco;
        }

        public override void Dispose()
        {
            Id = 0;
            base.Dispose();
            if (!(Endereco is null)) Endereco.Dispose();
        }

        private string removeMaskCPF(string cpf)
        {
            return cpf.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
        }
    }
}
