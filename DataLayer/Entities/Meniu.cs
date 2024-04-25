namespace CalotescuPractica.DataLayer.Entities
{
    public class Meniu
    {
        public int MeniuId { get; set; } 

        public string MeniuDenumire { get; set; } 

        public string MeniuPret {  get; set; }

        public string MeniuDescriere { get; set; }

        public int RestaurantID { get; set; }
        public List<Meniu> meniu { get; set; }
        public List<Comanda> Comanda { get; set; }


    }
}
