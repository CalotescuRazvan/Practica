namespace CalotescuPractica.DataLayer.Entities
{
    public class ContinutComanda
    {
        public int ContinutComandaId { get; set; }

        public int Cantitate { get; set; }

        public int MeniuId { get; set; }
        public Meniu meniu { get; set; }

        public int ComandaId { get; set; }
        public Comanda comanda { get; set; }
    }
}
