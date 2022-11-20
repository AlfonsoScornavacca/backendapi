using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.Responses;
using WebApplication1.Models.UpdateProductRequest;

namespace WebApplication1.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        //Ultimos cambios
        List<ProductResponse> GetAllProducts();
        Task DeleteProduct(int productId);
        Task UpdateProduct(int Id, Product product);
        Task<ProductResponse> GetProduct(int productId);


    }
}
