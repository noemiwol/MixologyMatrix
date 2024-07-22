using Microsoft.EntityFrameworkCore;
using MixologyMatrixMVC.Core.Entities;

namespace MixologyMatrixMVC.Infrastructure.Data
{
    // Dziedziczy po DbContext
    public class ApplicationDbContext : DbContext
    {
        // Konstruktor klasy ApplicationDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Zbiór encji Drink
        public DbSet<Drink> Drinks { get; set; }

        // Zbiór encji AlcoholicDrink
        public DbSet<AlcoholicDrink> AlcoholicDrinks { get; set; }

        // Konfiguracja modelu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodatkowa konfiguracja modelu, jeśli jest potrzebna
        }
    }
}
