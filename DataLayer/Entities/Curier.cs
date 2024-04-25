namespace CalotescuPractica.DataLayer.Entities
{
    public class Curier
    {
        public int CurierId { get; set; }
        public string CurierNume { get; set; }
        public string CurierTelefon { get; set; }

        public List<Comanda> Comanda { get; set; }

    }
}
