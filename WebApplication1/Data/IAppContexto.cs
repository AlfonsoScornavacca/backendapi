using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public interface IAppContexto
    {
        DbSet<Product> Products { get; set; }

        DbSet<Vendedor> Vendedores { get; set; }

         int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
