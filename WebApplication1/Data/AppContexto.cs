using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Data
{
    public class AppContexto : DbContext, IAppContexto
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }

        public AppContexto(DbContextOptions<AppContexto> options) : base(options) => this.Database.EnsureCreated();
    }
}
