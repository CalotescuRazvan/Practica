namespace CalotescuPractica.DataLayer.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public string ClientNume { get; set; }

        public string ClientAdresa { get; set; }

        public List<Comanda> Comanda { get; set; }

    }
}
