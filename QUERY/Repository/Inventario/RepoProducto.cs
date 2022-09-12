using DOMAIN.Entities.Inventario;
using DOMAIN.Interfaces.IRespositorio.Inventario;
using INFRASTRUCTURE.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Repository.Inventario
{
    public class RepoProducto : IProductoR
    {
        private readonly ApplicationDbContext _LContext;
        private  ApplicationDbContext _Context;

        public RepoProducto(ApplicationDbContext lContext, ApplicationDbContext context)
        {
            _LContext = lContext;
            _Context = context;
        }

        public async Task<List<Producto>> GetAllProduct()
        {
            return await _LContext.tbl_producto.Include(e => e.imagenes).ToListAsync();
        }
        public async Task<Producto> GetProductForId(Guid id)
        {
            return await _LContext.tbl_producto.Include(e => e.imagenes).Where(e=>e.Id==id).FirstOrDefaultAsync();
        }
        public async Task<Producto> InsertarProducto(Producto producto)
        {
            producto = await _Context.InsertarEntidad(producto);
 
            return producto;
        }
    }
}
