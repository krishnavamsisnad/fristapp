using CompanyofSnad.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyofSnad.Data
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
        public DbSet<Employes> Employes { get; set; }
        public DbSet<Employedetailes> Employedetailes { get; set; }
        public DbSet<Manager> Managers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employes>()
                .HasKey(E => E.EmployeId);
            modelBuilder.Entity<Employedetailes>().HasKey(l => l.EmployedetailesId);
            modelBuilder.Entity<Employedetailes>()
                .HasOne(e => e.Employes)
                .WithOne(p => p.Employedetailes)
                .HasForeignKey<Employedetailes>(ed => ed.Employeid);  
            modelBuilder.Entity<Manager>()
                .HasMany(u=>u.Employes).WithOne(y=>y.Manager);
           
       
        }
    }
}
