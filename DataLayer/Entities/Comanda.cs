namespace CalotescuPractica.DataLayer.Entities
{
    public class Comanda
    {
        public int ComandaID { get; set; }

        public DateTime DataComanda {  get; set; }
        public DateTime DataLivrare { get; set; }

        public int ClientId { get; set; }
        public Client client { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant restaurant { get; set; }

        public List<ContinutComanda> continutComanda { get; set; }
    }
}
