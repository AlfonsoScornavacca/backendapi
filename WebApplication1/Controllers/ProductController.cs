using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Responses;
using WebApplication1.Models.UpdateProductRequest;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly IAppContexto _appContexto;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CrearProducto([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return Ok(product);
        }
        [HttpGet]
 
        public ActionResult<IEnumerable<ProductResponse>> ObtenerProductos()
        {
            var products = _productService.GetAllProducts();

            return Ok(products);

        }
        //ultimos cambios
        [HttpGet]
        [Route("{productId}")]
       
        public async Task<ProductResponse> GetProduct(int productId) =>        
            await _productService.GetProduct(productId);

        

        [HttpDelete("{productId}")]
  

        public async Task <ActionResult> EliminarProducto (int productId)
        {
            await _productService.DeleteProduct(productId);
            return Ok();
        }

        [HttpPut("{productId}")]


        public async Task<ActionResult> UpdateProduct(int productId, Product product)
        {
            await _productService.UpdateProduct(productId, product);
            return Ok(product);    
        }
        /* public async Task <IActionResult> UpdateProduct( int id,  UpdateProductRequest updateProductRequest, AppContexto appContexto)
        {
          var product = await _appContexto.Products.FindAsync(id);

            if( product != null)
            {
                product.Name = updateProductRequest.Name;
                product.Price = updateProductRequest.Price;

                await _appContexto.SaveChangesAsync();

                return Ok(product);
            }

            return NotFound();

        }*/

    }
}