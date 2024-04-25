namespace CalotescuPractica.DataLayer.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        public string RestaurantNume { get; set; }

        public string RestaurantDescriere { get; set; }

        public string RestaurantAdresa { get; set; }

        public List<Meniu> Meniuri { get; set; }
        public List<Comanda> Comanda { get; set; }
        

    }
}
