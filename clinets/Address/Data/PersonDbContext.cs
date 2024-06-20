using Microsoft.EntityFrameworkCore;
using Address.Model;

namespace Address.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<Addressdata> Addressdata { get; set; }
        public DbSet<Departement> Department { get; set; }
        public DbSet<Persondata> Persondata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Department entity
            modelBuilder.Entity<Departement>()
                .ToTable("Dept")
                .HasKey(d => d.DepatemntId);

            // Configure Persondata entity
            modelBuilder.Entity<Persondata>()
                .HasKey(p => p.PersonId); // Ensure this is set as the primary key

            modelBuilder.Entity<Persondata>()
                .Property(p => p.PersonName)
                .HasColumnName("Pname")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            // Configure Addressdata entity
            modelBuilder.Entity<Addressdata>()
                .HasKey(a => a.PersonId); // Ensure this is set as the primary key

            // One-to-one relationship between Persondata and Addressdata
            modelBuilder.Entity<Persondata>()
                .HasOne(p => p.Addressdata)
                .WithOne(a => a.Persondata)
                .HasForeignKey<Addressdata>(a => a.PersonId);
        }
    }
}

