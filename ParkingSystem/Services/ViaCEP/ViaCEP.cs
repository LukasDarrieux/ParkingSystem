using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ParkingSystem.Services.ViaCEP
{
    class ViaCEP
    {
        private static CEP Cep = null;

        public static CEP BuscarCEP(string cep)
        {
            Request(cep);
            return Cep;
        }

        private static void Request(string cep)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                var request = WebRequest.CreateHttp(url);
                request.Method = "GET";

                using (var resposta = request.GetResponse())
                {
                    using (var response = resposta.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(response);
                        var viaCep = JsonConvert.DeserializeObject<CEP>(reader.ReadToEnd());
                        Cep = viaCep;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
