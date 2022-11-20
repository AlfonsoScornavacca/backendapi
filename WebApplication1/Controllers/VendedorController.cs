using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route ("api/vendedores")]
    public class VendedorController :  ControllerBase
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController(IVendedorService vendedorService) => _vendedorService = vendedorService;

        [HttpPost]
        public async Task<ActionResult> CrearVendedor([FromBody] Vendedor vendedor)
        {
            await _vendedorService.AddVendedor(vendedor);
            return Ok(vendedor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<VendedorResponse>> ObtenerVendedor()
        {
            var vendedores = _vendedorService.GetAllVendedores();

            return Ok(vendedores);

        }
        //ultimos cambios
        [HttpGet]
        [Route("{vendedorId}")]
        public async Task<VendedorResponse> GetVendedor(int vendedorId) =>
            await _vendedorService.GetVendedor(vendedorId);

        [HttpPut]
        [Route ("baja/{vendedorId}")]
        public async Task<ActionResult> EliminarVendedor(int vendedorId)
        {
            await _vendedorService.DeleteVendedor(vendedorId);
            return Ok();
        }

        [HttpPut]
        [Route("{vendedorId}")]
        public async Task<ActionResult> UpdateVendedor(int vendedorId, Vendedor vendedor)
        {
            await _vendedorService.UpdateVendedor(vendedorId, vendedor);
            return Ok(vendedor);
        }

    }
}
