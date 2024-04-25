using CalotescuPractica.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalotescuPractica.DataLayer
{
    public class TazzDB : DbContext
    {
        public TazzDB(DbContextOptions<TazzDB> options) : base(options) { }



        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Curier> Curier { get; set; }
        public DbSet<ContinutComanda> ContinutComanda { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Meniu> Meniu { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }



    }

  

}
