using company.Models;
using Microsoft.EntityFrameworkCore;

namespace company.Data
{
    public class CompanyDbContext :DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
        public DbSet<Companydata> Companydata { get; set; }
        public DbSet<Rengion> Rengion { get; set; }
        public DbSet <Difficulty> Difficulty { get; set; }
        public DbSet <Walk> Walk { get; set; }
    }
}
