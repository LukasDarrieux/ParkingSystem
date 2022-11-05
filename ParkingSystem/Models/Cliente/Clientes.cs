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
            set => _cpf = RemoveMaskCPF(value);
            
        }
        public Enderecos Endereco { get; set; }

        public Clientes(int id, string nome, string email, string cpf, Enderecos endereco) : base(nome, email)
        {
            Id = id;
            _cpf = RemoveMaskCPF(cpf);
            Endereco = endereco;
        }

        public override void Dispose()
        {
            Id = 0;
            base.Dispose();
            if (!(Endereco is null)) Endereco.Dispose();
        }

        private string RemoveMaskCPF(string cpf)
        {
            return cpf.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is Clientes)
            {
                return (((Clientes)obj).Id != Id && 
                    ((Clientes)obj).Nome == Nome && 
                    ((Clientes)obj).Cpf == Cpf &&
                    ((Clientes)obj).Email == Email);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
