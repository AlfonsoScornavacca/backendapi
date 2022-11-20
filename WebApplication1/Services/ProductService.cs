using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.Responses;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IAppContexto _appContexto;

        public ProductService(IAppContexto appContexto) 
        {
            _appContexto = appContexto;
        }

        public async Task AddProduct(Product product)
        {
            _appContexto.Products.Add(product);

           await _appContexto.SaveChangesAsync();
        }

        public List<ProductResponse> GetAllProducts()=>        
             _appContexto.Products
                      .Select(x => x)
                      .ToList()
                      .Select(x => Map(x))
                      .ToList();                 
        

        private ProductResponse Map(Product product)=>       
             new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };      
        
        public async Task DeleteProduct(int productId)
        {
            var product = _appContexto.Products.Where(x => x.Id == productId).First();
            _appContexto.Products.Remove(product);

            await _appContexto.SaveChangesAsync();
        }

        public async Task UpdateProduct(int Id, Product product)
        {
            var productUpdated = _appContexto.Products.Update(product).Entity;
            await _appContexto.SaveChangesAsync();

           
        }
        //Ultimos cambios
        public async Task <ProductResponse> GetProduct(int productId)
        {
            //var product = _appContexto.Products.Where(x => x.Id == productId).First();
            //return await MapProduct(product);
            return _appContexto.Products.Where(x => x.Id == productId)
                                        .Select(p => new ProductResponse { Id = p.Id, Name = p.Name, Price=p.Price})
                                        .First();
        }
    }
}
