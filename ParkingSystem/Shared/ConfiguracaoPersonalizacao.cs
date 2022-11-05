using ParkingSystem.Utils.Interfaces;
using System;

namespace ParkingSystem.Shared
{
    class ConfiguracaoPersonalizacao : IDisposable
    {
        public string Titulo { get; private set; }
        
        public ConfiguracaoPersonalizacao(string titulo)
        {
            Titulo = titulo;
        }

        public void Dispose()
        {
            Titulo = null;
        }
    }
}
