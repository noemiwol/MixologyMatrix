using Microsoft.EntityFrameworkCore;
using MixologyMatrixMVC.Core.Entities;

namespace MixologyMatrixMVC.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<AlcoholicDrink> AlcoholicDrinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drink>()
                .HasDiscriminator<string>("DrinkType")
                .HasValue<Drink>("NonAlcoholic")
                .HasValue<AlcoholicDrink>("Alcoholic");
        }
    }
}
