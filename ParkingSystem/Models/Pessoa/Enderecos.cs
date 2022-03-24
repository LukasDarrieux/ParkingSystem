using System;

namespace ParkingSystem.Models.Pessoa
{
    class Enderecos : IDisposable
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }

        public Enderecos(string logradouro, string numero, string bairro, string cidade, string uf)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uf;
        }

        public void Dispose()
        {
            Logradouro = null;
            Numero = null;
            Bairro = null;
            Cidade = null;
            UF = null;
        }
    }
}
