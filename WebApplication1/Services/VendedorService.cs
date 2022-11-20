using WebApplication1.Data;
using WebApplication1.Models.Responses;

namespace WebApplication1.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IAppContexto _appContexto;

        public VendedorService(IAppContexto appContexto)
        {
            _appContexto = appContexto;
        }

        public async Task AddVendedor(Vendedor vendedor)
        {
            try
            {
                _appContexto.Vendedores.Add(vendedor);

                await _appContexto.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }

        public List<VendedorResponse> GetAllVendedores()
        {
            try
            {
                return _appContexto.Vendedores
                         .Where(x => x.IsActive == true)
                         .Select(x => x)
                         .ToList()
                         .Select(x => Map(x))
                         .ToList();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);

                return null;
            }
        }

        private VendedorResponse Map(Vendedor vendedor) =>
             new VendedorResponse
             {
                 Id = vendedor.Id,
                 Name = vendedor.Name,
                 LastName = vendedor.LastName,
                 IsActive = vendedor.IsActive,
             };

        public async Task DeleteVendedor(int vendedorId)
        {
            var vendedor = _appContexto.Vendedores
                .Where(x => x.Id == vendedorId)
                .First();
            if(vendedor.IsActive == true)
            {
                vendedor.IsActive = false;
            }
            else
            {
                vendedor.IsActive = true;
            }
          var vendedorBaja =  _appContexto.Vendedores.Update(vendedor).Entity;

            await _appContexto.SaveChangesAsync();
        }

        public async Task UpdateVendedor(int id,Vendedor vendedor)
        {
            var vendedorUpdated = _appContexto.Vendedores
                .Update(vendedor).Entity;
            await _appContexto
                .SaveChangesAsync();


        }
        public async Task<VendedorResponse> GetVendedor(int vendedorId)
        {
            return _appContexto.Vendedores
                         .Where(x => x.Id == vendedorId && x.IsActive == true)
                         .Select(v => new VendedorResponse { Name = v.Name, LastName = v.LastName })
                         .First();
        }
    }
}
