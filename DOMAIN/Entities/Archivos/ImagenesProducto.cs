using DOMAIN.Entities.Inventario;
using DOMAIN.Helper.Generador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Archivos
{
    public class ImagenesProducto:Entity<Guid>
    {
        public Guid? Id_procuto { set; get; }
        public string? name { get; set; }
        public string? Description { get; set; }
        public string? RouteFile { get; set; }
        public Producto? Producto { set; get; }
    }
}
