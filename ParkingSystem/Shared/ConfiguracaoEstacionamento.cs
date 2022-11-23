namespace ParkingSystem.Shared
{
    class ConfiguracaoEstacionamento
    {
        public enum Campos
        {
            ID,
            CARRO,
            MOTO,
            PERNOITE
        }

        public int Id { get; private set; }
        public double Carro { get; private set; }
        public double Moto { get; private set; }
        public double PerNoite { get; private set; }

        public ConfiguracaoEstacionamento(int id, double carro, double moto, double perNoite)
        {
            Id = id;
            Carro = carro;
            Moto = moto;
            PerNoite = perNoite;
        }
    }
}
