using Cakes.Models;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Data
{
    public class CakeDbContext : DbContext
    {
        public CakeDbContext(DbContextOptions<CakeDbContext> options) : base(options) { }

        public DbSet<Cakesdata> Cakesdatas { get; set; }
        public DbSet<Branchdata> Branchdatas { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("your_connection_string",
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cakesdata>()
                .HasOne(c => c.Delivery)
                .WithOne(d => d.Cakesdata)
                .HasForeignKey<Delivery>(d => d.CakesId)
                .IsRequired(); // Ensures that CakesdataId must have a value and be unique

            base.OnModelCreating(modelBuilder);
        }

    }
}
