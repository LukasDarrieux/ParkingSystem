using System;

namespace ParkingSystem.Models.Pessoa
{
    class Enderecos : IDisposable
    {
        private string _cep;

        public string CEP { get => _cep; set => _cep = value.Replace("-", "").Trim(); }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }

        public Enderecos(string logradouro, string numero, string bairro, string cidade, string uf)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public Enderecos(string cep, string logradouro, string numero, string bairro, string cidade, string uf)
        {
            CEP = cep.Replace("-", "").Trim();
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public void Dispose()
        {
            _cep = null;
            Logradouro = null;
            Numero = null;
            Bairro = null;
            Cidade = null;
            UF = null;
        }
    }
}
