using ASP_API_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Location> Locations { get; set; }

        // Si queremos que al momento de mostrar nuestros datos no se muestre el nombre en plural (Clients o Locations)
        // Sobreescribimos el metodo OnModelCreating de la clase DbContext
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().ToTable("Client");

        //    modelBuilder.Entity<Location>().ToTable("Location");
        //}
    }
}
