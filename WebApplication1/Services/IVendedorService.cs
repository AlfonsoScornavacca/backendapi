using WebApplication1.Data;
using WebApplication1.Models.Responses;

namespace WebApplication1.Services
{
    public interface IVendedorService
    {
        Task AddVendedor(Vendedor vendedor);
        List<VendedorResponse> GetAllVendedores();
        Task DeleteVendedor(int vendedorId);
        Task UpdateVendedor(int id, Vendedor vendedor);
        Task<VendedorResponse> GetVendedor(int vendedorId);
    }
}
