using DOMAIN.Dtos.Inventario;
using DOMAIN.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IRespositorio.Inventario
{
    public interface IProductoR
    {
        Task<List<Producto>> GetAllProduct();
        Task<Producto> GetProductForId(Guid guid);
        Task<Producto> InsertarProducto(Producto producto);
    }
}
