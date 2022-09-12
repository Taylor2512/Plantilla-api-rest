using DOMAIN.Entities.Inventario;
using DOMAIN.Entities.Persona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Interface.Inventario
{
    internal interface IConfigInventario: IEntityTypeConfiguration<Producto>
    {
    }
}
