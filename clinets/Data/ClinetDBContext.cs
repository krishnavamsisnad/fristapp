using clinets.Models;
using Microsoft.EntityFrameworkCore;

namespace clinets.Data
{
    public class ClinetDBContext : DbContext
    {
        public ClinetDBContext(DbContextOptions<ClinetDBContext>options):base(options)
        {

        }
        public DbSet<Clinetsdata> Clinetsdata { get; set; } 
    }
}
