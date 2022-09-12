using DOMAIN.Dtos.Inventario;
using DOMAIN.Entities.Inventario;
using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IExtensionS.Inventario;
using DOMAIN.Interfaces.IServices.Inventario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackStore.Controllers.Inventario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IExtensionServices<IExtensionInventarioS> servicio;

        public ProductoController(IExtensionServices<IExtensionInventarioS> servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<List<ProductoGetDto>>> GetProductos()
        {
            List<ProductoGetDto> encontrado = await servicio.Extension.ProductoS.GetAllProduct();

            return Ok(encontrado);
        }
        [HttpGet("{id}",Name = "GetProductosForId")]
        public async Task<ActionResult<ProductoDto>> GetProductosForId(string id)
        {
            ProductoDto encontrado = await servicio.Extension.ProductoS.GetProductForId(Guid.Parse(id));
            return Ok(encontrado);
        }
        [HttpPost(Name ="PostPRoducto")]
        public async Task<ActionResult<object>> PostPRoducto([FromForm][FromBody] ProductoDto entidad)
        {
            var producto = await servicio.Extension.ProductoS.RegistrarProducto(entidad);
          
            return Created(Url.Link("GetProductosForId", new { producto.Id}) , producto);
        }
     

    }
}
