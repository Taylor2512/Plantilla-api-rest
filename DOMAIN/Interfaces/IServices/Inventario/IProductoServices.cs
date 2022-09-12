using AutoMapper;
using DOMAIN.Dtos.Inventario;
using DOMAIN.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IServices.Inventario
{
    public interface IProductoServices
    {
        
        Task<List<ProductoGetDto>> GetAllProduct();
        Task<ProductoDto> GetProductForId(Guid guid);
        Task<Producto> RegistrarProducto(ProductoDto entidad);
    }
}
