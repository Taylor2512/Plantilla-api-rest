using DOMAIN.Entities.Inventario;
using DOMAIN.Helper.Enums.DB;
using INFRASTRUCTURE.Interface.Inventario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Config.Inventario
{
    internal class InventarioDbConfig : IConfigInventario
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable(TableDB.tbl_producto.ToString());
            builder.HasMany(e=>e.imagenes).WithOne(e=>e.Producto).HasForeignKey(e=>e.Id_procuto);
        }
    }
}
