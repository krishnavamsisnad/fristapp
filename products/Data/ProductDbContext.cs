using Microsoft.EntityFrameworkCore;
using products.Models;
namespace products.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Products> Products{ get; set; }
    }
}
