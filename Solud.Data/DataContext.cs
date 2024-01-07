
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;

namespace Solid.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Travels> Travels { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=traveling_db");
        }

    }
}
