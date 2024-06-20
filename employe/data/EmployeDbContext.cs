using Employe.Model;
using Microsoft.EntityFrameworkCore;

namespace Employe.data
{
    public class EmployeDbContext:DbContext
    {
        public EmployeDbContext(DbContextOptions<EmployeDbContext> options) : base(options) { }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saralydata>()
                .HasOne(p =>p.Employ)
                .WithOne(p=>p.Saralydata)
                .HasForeignKey<Employ>(p=>p.EmployeId);
        }
        public DbSet<Saralydata> Saralydata { get; set; }
        public DbSet<Employ> Employs { get; set; }
    }

}
