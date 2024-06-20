using Microsoft.EntityFrameworkCore;
using snad.Models;

namespace snad.Data
{
    public class SnadContext:DbContext
    {
        public SnadContext(DbContextOptions<SnadContext>options) : base(options)
        {

        }
        public DbSet<Snaddata> Snaddata { get; set; }
    }
}
