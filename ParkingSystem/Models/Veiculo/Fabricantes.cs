using System;


namespace ParkingSystem.Models.Veiculo
{
    class Fabricantes : IDisposable
    {
        public enum Campos
        {
            ID, 
            NOME,
            LAST = NOME
        }


        public string Nome { get; set; }
        public bool Importado { get; set; }

        public Fabricantes(string nome, bool importado)
        {
            this.Nome = nome;
            this.Importado = importado;
        }

        public void Dispose()
        {
            Nome = null;
            Importado = false;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
