using DOMAIN.Helper.Generador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Inventario
{
    public class Producto : Entity<Guid>
    {
     public string NameProduct { set; get; }

    }
}
