namespace ParkingSystem.Services.ViaCEP
{
    class CEP
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string DDD { get; set; }
        public string Siafi { get; set; }

        public CEP()
        {

        }

        public CEP(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string dDD, string siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            DDD = dDD;
            Siafi = siafi;
        }
    }
}
