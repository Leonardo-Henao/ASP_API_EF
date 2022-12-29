using ASP_API_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Data
{
    public class DataContext : DbContext
    {

        public DataContext() { }

        public DataContext(DbContextOptions options): base(options)
        {
         
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        // Si queremos que al momento de mostrar nuestros datos no se muestre el nombre en plural (Clients o Locations)
        // Sobreescribimos el metodo OnModelCreating de la clase DbContext
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().ToTable("Client");

        //    modelBuilder.Entity<Location>().ToTable("Location");
        //}
    }
}
